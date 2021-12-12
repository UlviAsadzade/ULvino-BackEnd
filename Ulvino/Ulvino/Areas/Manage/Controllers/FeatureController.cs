using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Helpers;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public FeatureController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Feature> features = _context.Features.ToList();
            return View(features);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Feature feature)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (feature.ImageFile != null)
            {
                if (feature.ImageFile.ContentType != "image/jpeg" && feature.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (feature.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/feature", feature.ImageFile);

                feature.Image = fileName;
            }

            _context.Features.Add(feature);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);

            if (feature == null) return RedirectToAction("index", "error", new { area = "" });

            return View(feature);
        }


        [HttpPost]
        public IActionResult Edit(Feature feature)
        {
            if (!ModelState.IsValid) return View();

            Feature existFeature = _context.Features.FirstOrDefault(x => x.Id == feature.Id);

            if (existFeature == null) return RedirectToAction("index", "error", new { area = "" });

            string fileName = null;
            if (feature.ImageFile != null)
            {
                if (feature.ImageFile.ContentType != "image/png" && feature.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (feature.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                fileName = FileManager.Save(_env.WebRootPath, "uploads/feature", feature.ImageFile);
            }

            if (fileName != null || feature.Image == null)
            {
                if (existFeature.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/feature", existFeature.Image);
                }

                existFeature.Image = fileName;
            }

            existFeature.Title = feature.Title;
            existFeature.Desc = feature.Desc;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);

            if (feature == null) return Json(new { status = 404 });

            try
            {
                if (feature.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/feature", feature.Image);
                }
                _context.Features.Remove(feature);
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
