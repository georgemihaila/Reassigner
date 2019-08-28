using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reassigner.Infrastructure;
using Reassigner.Infrastructure.Entities;
using Reassigner.Infrastructure.Extensions;
using Reassigner.Infrastructure.FileHandlers;
using Reassigner.Infrastructure.FileHandling.Abstractions;
using Reassigner.Models;

namespace Reassigner.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Route("Agents/[action]")]
    public class AgentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles an Excel file upload and updates agent data accordingly.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UploadAgentData(List<IFormFile> files)
        {
            var filePath = Path.GetTempFileName();
            if (files.Count == 1 && files[0].Length > 0 && (files[0].FileName.ToUpper().EndsWith(".XLS") || files[0].FileName.ToUpper().EndsWith(".XLSX")))
            {
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await files[0].CopyToAsync(stream);
                }
                using (ExcelFile file = new ExcelFile(filePath))
                {
                    _context.Agents.RemoveRange(_context.Agents);
                    var agents = file.AsEntityList<Agent>(x => x.Replace(" ", string.Empty).ToUpper());
                    agents.DistinctBy(x => x.Username).ToList().ForEach(x => _context.Agents.Add(x));
                    await _context.SaveChangesAsync();
                }
                System.IO.File.Delete(filePath);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_context.Agents);
        }
    }
}