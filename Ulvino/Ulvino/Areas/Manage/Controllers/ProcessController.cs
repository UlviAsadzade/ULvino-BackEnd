using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class ProcessController : Controller
    {
        private readonly AppDbContext _context;


        public ProcessController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            List<Process> processes = _context.Processes.ToList();

            return View(processes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Process process)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Processes.Add(process);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Process process = _context.Processes.FirstOrDefault(x => x.Id == id);

            if (process == null) return RedirectToAction("index", "error", new { area = "" });

            return View(process);
        }

        [HttpPost]
        public IActionResult Edit(Process process)
        {
            Process existProcess = _context.Processes.FirstOrDefault(x => x.Id == process.Id);

            if (existProcess == null) return RedirectToAction("index", "error", new { area = "" });

            existProcess.Title = process.Title;
            existProcess.Icon = process.Icon;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Process process = _context.Processes.FirstOrDefault(x => x.Id == id);

            if (process == null) return Json(new { status = 404 });

            try
            {
                _context.Processes.Remove(process);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
