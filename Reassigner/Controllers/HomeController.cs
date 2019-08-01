using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reassigner.Models;

namespace Reassigner.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Home/{action}")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(new DashboardViewModel()
            {
                Assigned = _context.Tickets.Count(o => o.State == Infrastructure.Entities.State.Assigned),
                Unassigned = _context.Tickets.Count(o => o.State == Infrastructure.Entities.State.Unassigned),
                Rules = _context.Rules.Count(),
                Queued = _context.ReassignmentEntries.Count(o => o.CompletedTime != null)
            });
        }
    }
}
