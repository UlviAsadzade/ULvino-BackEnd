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

    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.ToList();
            return View(blogs);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Blog blog)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (blog.ImageFile != null)
            {
                if (blog.ImageFile.ContentType != "image/jpeg" && blog.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (blog.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/blog", blog.ImageFile);

                blog.Image = fileName;
            }

            if (blog.Order < 0)
            {
                ModelState.AddModelError("Order", "Order can not be less than 0");
                return View();

            }

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            if (blog == null) return RedirectToAction("index", "error", new { area = "" });

            return View(blog);
        }


        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            if (!ModelState.IsValid) return View();

            Blog existBlog = _context.Blogs.FirstOrDefault(x => x.Id == blog.Id);

            if (existBlog == null) return RedirectToAction("index", "error", new { area = "" });

            string fileName = null;
            if (blog.ImageFile != null)
            {
                if (blog.ImageFile.ContentType != "image/png" && blog.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (blog.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                fileName = FileManager.Save(_env.WebRootPath, "uploads/blog", blog.ImageFile);
            }

            if (fileName != null || blog.Image == null)
            {
                if (existBlog.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/blog", existBlog.Image);
                }

                existBlog.Image = fileName;
            }

            if (blog.Order < 0)
            {
                ModelState.AddModelError("Order", "Order can not be less than 0");
                return View();

            }

            existBlog.Order = blog.Order;
            existBlog.Name = blog.Name;
            existBlog.Owner = blog.Owner;
            existBlog.Date = blog.Date;
            existBlog.Desc1 = blog.Desc1;
            existBlog.Desc2 = blog.Desc2;
            existBlog.Desc3 = blog.Desc3;
            existBlog.Desc4 = blog.Desc4;
            existBlog.Desc5 = blog.Desc5;


            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            if (blog == null) return Json(new { status = 404 });

            try
            {
                if (blog.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/blog", blog.Image);
                }
                _context.Blogs.Remove(blog);
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
