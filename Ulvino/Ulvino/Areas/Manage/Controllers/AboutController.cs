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

    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public AboutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            About about = _context.Abouts.FirstOrDefault();
            return View(about);
        }


        public IActionResult Edit()
        {
            About about = _context.Abouts.FirstOrDefault();
            return View(about);
        }


        [HttpPost]
        public IActionResult Edit(About about)
        {

            About existAbout = _context.Abouts.FirstOrDefault();
            if (existAbout == null) return RedirectToAction("index", "error", new { area = "" });

            if (!ModelState.IsValid) return View(existAbout);


            if (about.ImageFile != null)
            {
                if (about.ImageFile.ContentType != "image/png" && about.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View(existAbout);
                }

                if (about.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View(existAbout);
                }

                if (existAbout.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/about", existAbout.Image);
                }

                string aboutFileName = FileManager.Save(_env.WebRootPath, "uploads/about", about.ImageFile);

                existAbout.Image = aboutFileName;

            }
            else
            {
                if (about.Image == null)
                {
                    if (existAbout.Image != null)
                    {
                        FileManager.Delete(_env.WebRootPath, "uploads/about", existAbout.Image);
                        existAbout.Image = null;
                    }
                }
            }

            existAbout.Title = about.Title;
            existAbout.Desc = about.Desc;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
