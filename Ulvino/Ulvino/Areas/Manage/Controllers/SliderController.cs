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

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Slider slider)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/slider", slider.ImageFile);

                slider.Image = fileName;
            }

            if (slider.Order < 0)
            {
                ModelState.AddModelError("Order", "Order can not be less than 0");
                return View();

            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null) return RedirectToAction("index", "error", new { area = "" });

            return View(slider);
        }


        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            Slider existslider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            if (existslider == null) return RedirectToAction("index", "error", new { area = "" });

            string fileName = null;
            if (slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View(existslider);
                }

                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View(existslider);
                }

                fileName = FileManager.Save(_env.WebRootPath, "uploads/slider", slider.ImageFile);
            }

            if (fileName != null || slider.Image == null)
            {
                if (existslider.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/slider", existslider.Image);
                }

                existslider.Image = fileName;
            }

            if (slider.Order < 0)
            {
                ModelState.AddModelError("Order", "Order can not be less than 0");
                return View();

            }

            existslider.Order = slider.Order;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null) return Json(new { status = 404 });

            try
            {
                if (slider.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/slider", slider.Image);
                }
                _context.Sliders.Remove(slider);
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
