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

    public class RegionController : Controller
    {
        private readonly AppDbContext _context;

        public RegionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Region> regions = _context.Regions.ToList();

            return View(regions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Region region)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Regions.Add(region);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Region region = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null) return RedirectToAction("index", "error", new { area = "" });

            return View(region);
        }

        [HttpPost]
        public IActionResult Edit(Region region)
        {
            Region existRegion = _context.Regions.FirstOrDefault(x => x.Id == region.Id);

            if (existRegion == null) return RedirectToAction("index", "error", new { area = "" });

            existRegion.Name = region.Name;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Region region = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null) return Json(new { status = 404 });

            try
            {
                _context.Regions.Remove(region);
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
