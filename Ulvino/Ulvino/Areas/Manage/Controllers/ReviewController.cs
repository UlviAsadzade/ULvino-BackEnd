using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Review> reviews = _context.Reviews.Include(x => x.AppUser).ToList();

            return View(reviews);
        }

        public IActionResult Edit(int id)
        {
            Review review = _context.Reviews.Include(x => x.Product).Include(x => x.AppUser).FirstOrDefault(x => x.Id == id);

            return View(review);
        }

        public IActionResult Accept(int id)
        {
            Review review = _context.Reviews.FirstOrDefault(x => x.Id == id);

            if (review == null) return RedirectToAction("index", "error", new { area = "" });

            review.IsAccepted = true;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Reject(int id)
        {
            Review review = _context.Reviews.FirstOrDefault(x => x.Id == id);

            if (review == null) return RedirectToAction("index", "error", new { area = "" });

            review.IsAccepted = false;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
