using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]

    public class TypeController : Controller
    {
        private readonly AppDbContext _context;
        public TypeController(AppDbContext context)
        {
            _context = context;
        }

       public IActionResult Index()
        {
            List<Models.Type> types = _context.Types.ToList();

            return View(types);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Type type)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Types.Add(type);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Models.Type type = _context.Types.FirstOrDefault(x => x.Id == id);

            if (type == null) return RedirectToAction("index", "error", new { area = "" });

            return View(type);
        }

        [HttpPost]
        public IActionResult Edit(Models.Type type)
        {
            Models.Type existType = _context.Types.FirstOrDefault(x => x.Id == type.Id);

            if (existType == null) return RedirectToAction("index", "error", new { area = "" });

            existType.Name = type.Name;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Models.Type type = _context.Types.FirstOrDefault(x => x.Id == id);

            if (type == null) return Json(new { status = 404 });

            try
            {
                _context.Types.Remove(type);
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
