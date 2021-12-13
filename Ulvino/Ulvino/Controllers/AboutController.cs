using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;
using Ulvino.ViewModels;

namespace Ulvino.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                Abouts = _context.Abouts.FirstOrDefault(),
                Features = _context.Features.ToList(),
                Processes = _context.Processes.ToList(),
                Teams = _context.Teams.ToList(),
                Settings = _context.Settings.FirstOrDefault()

            };

            return View(aboutVM);
        }
    }
}
