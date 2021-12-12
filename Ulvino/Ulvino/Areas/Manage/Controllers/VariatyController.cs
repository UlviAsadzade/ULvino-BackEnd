using Microsoft.AspNetCore.Authorization;
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

    public class VariatyController : Controller
    {
        private readonly AppDbContext _context;
        public VariatyController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Variaty> variaties = _context.Variaties.ToList();

            return View(variaties);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Variaty variaty)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Variaties.Add(variaty);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Variaty variaty = _context.Variaties.FirstOrDefault(x => x.Id == id);

            if (variaty == null) return RedirectToAction("index", "error", new { area = "" });

            return View(variaty);
        }

        [HttpPost]
        public IActionResult Edit(Variaty variaty)
        {
            Variaty existVariaty = _context.Variaties.FirstOrDefault(x => x.Id == variaty.Id);

            if (existVariaty == null) return RedirectToAction("index", "error", new { area = "" });

            existVariaty.Name = variaty.Name;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Variaty variaty = _context.Variaties.FirstOrDefault(x => x.Id == id);

            if (variaty == null) return Json(new { status = 404 });

            try
            {
                _context.Variaties.Remove(variaty);
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
