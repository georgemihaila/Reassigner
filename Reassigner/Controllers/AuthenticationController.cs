using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Reassigner.Infrastructure.Authentication;
using Reassigner.Models;

namespace Reassigner.Controllers
{
    [Route("/auth/{action}")]
    public class AuthenticationController : Controller
    {
        private readonly ICustomAuthenticationService _authenticationService;

        public AuthenticationController(ICustomAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_authenticationService.ValidateCredentials(model.Username, model.Password))
                    {
                        await LoginAsync(model.Username, model.Password);
                        if (IsUrlValid(model.ReturnUrl))
                            return Redirect(model.ReturnUrl);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    ModelState.AddModelError("InvalidCredentials", "Invalid credentials.");
                }
            }
            return View(model);
        }

        private static bool IsUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl)
                   && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        private async Task LoginAsync(string domainUsername, string password)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, domainUsername),
                new Claim(ClaimTypes.Role, "User")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}