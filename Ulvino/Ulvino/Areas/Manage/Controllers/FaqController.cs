using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]

    public class FaqController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public FaqController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Faq> faqs = _context.Faqs.ToList();

            return View(faqs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Faq faq)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (faq.Order < 0)
            {
                ModelState.AddModelError("Order", "Order can not be less than 0");
                return View();

            }
            _context.Faqs.Add(faq);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);

            if (faq == null) return RedirectToAction("index", "error", new { area = "" });

            return View(faq);
        }

        [HttpPost]
        public IActionResult Edit(Faq faq)
        {
            Faq existFaq = _context.Faqs.FirstOrDefault(x => x.Id == faq.Id);

            if (existFaq == null) return RedirectToAction("index", "error", new { area = "" });

            if (faq.Order < 0)
            {
                ModelState.AddModelError("Order", "Order can not be less than 0");
                return View();

            }

            existFaq.Order = faq.Order;
            existFaq.Question = faq.Question;
            existFaq.Answer = faq.Answer;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);

            if (faq == null) return Json(new { status = 404 });

            try
            {
                _context.Faqs.Remove(faq);
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
