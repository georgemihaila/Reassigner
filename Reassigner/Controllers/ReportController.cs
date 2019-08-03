using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return View(new ReportsViewModel()
            {
                Collection = _context.ReassignmentEntries
            });
        }

        public IActionResult RuleReport(string ruleId)
        {
            return View(new DetailedReportViewModel()
            {
                Rule = _context.Rules.FirstOrDefault(o => o.ID == ruleId),
                Entries = _context.ReassignmentEntries.Where(o => o.Rule.ID == ruleId)
            });
        }
    }
}