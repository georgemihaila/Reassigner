using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reassigner.Infrastructure;
using Reassigner.Infrastructure.Entities;
using Reassigner.Models;

namespace Reassigner.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Rules/{action}")]
    public class RulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Rules);
        }

        public IActionResult Edit(string id)
        {
            return (id == null || _context.Rules.Count(o => o.ID == id) == 0) ? View() : View(_context.Rules.First(o => o.ID == id));
        }

        [HttpPost]
        public IActionResult Enable(string id) => SetEnabled(id, true);

        [HttpPost]
        public IActionResult Disable(string id) => SetEnabled(id, false);

        private IActionResult SetEnabled(string ruleId, bool enabled)
        {
            if (_context.Rules.Count(o => o.ID == ruleId) == 0)
                return StatusCode(StatusCodes.Status400BadRequest);
            _context.Rules.First(o => o.ID == ruleId).Enabled = enabled;
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}