using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.ToList();

            return View(blogs);
        }

        public IActionResult Detail(int id)
        {
            if (!ModelState.IsValid) return RedirectToAction("index", "error");

            Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            return View(blog);
        }
    }
}
