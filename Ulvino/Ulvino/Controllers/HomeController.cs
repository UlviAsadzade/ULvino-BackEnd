using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;
using Ulvino.ViewModels;

namespace Ulvino.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),
                Blogs = _context.Blogs.Take(4).ToList(),
                FeaturedProducts = _context.Products.Include(x=>x.ProductImages).Where(x=>x.IsFeatured).Take(8).ToList(),
                PopularProducts = _context.Products.Include(x=>x.ProductImages).Where(x=>x.Rate>4).Take(8).ToList(),
                Customers = _context.Customers.ToList(),
                Settings = _context.Settings.FirstOrDefault()
            };

            return View(homeVM);
        }

        
    }
}
