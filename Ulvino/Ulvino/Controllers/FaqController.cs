using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.Controllers
{
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Faq> faqs = _context.Faqs.ToList();

            return View(faqs);
        }
    }
}
