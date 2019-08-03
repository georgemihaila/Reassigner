using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reassigner.Infrastructure.Entities;
using Reassigner.Models;

namespace Reassigner.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Reports/[action]")]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ReassignmentEntries as IEnumerable<IReassignmentEntry<ITicket, IAgent, IRule>>);
        }

        public IActionResult RuleReport(string ruleId)
        {
            return View(new DetailedReportViewModel()
            {
                Rule = _context.Rules.FirstOrDefault(o => o.ID == ruleId),
                Entries = _context.ReassignmentEntries.Where(o => o.Rule.ID == ruleId) as IEnumerable<IReassignmentEntry<ITicket, IAgent, IRule>>
            });
        }
    }
}