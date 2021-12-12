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

    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public CustomerController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Customer> customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (customer.ImageFile != null)
            {
                if (customer.ImageFile.ContentType != "image/jpeg" && customer.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (customer.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/customer", customer.ImageFile);

                customer.Image = fileName;
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null) return RedirectToAction("index", "error", new { area = "" });

            return View(customer);
        }


        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View();

            Customer existCustomer = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);

            if (existCustomer == null) return RedirectToAction("index", "error", new { area = "" });

            string fileName = null;
            if (customer.ImageFile != null)
            {
                if (customer.ImageFile.ContentType != "image/png" && customer.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (customer.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                fileName = FileManager.Save(_env.WebRootPath, "uploads/customer", customer.ImageFile);
            }

            if (fileName != null || customer.Image == null)
            {
                if (existCustomer.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/customer", existCustomer.Image);
                }

                existCustomer.Image = fileName;
            }


            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null) return Json(new { status = 404 });

            try
            {
                if (customer.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/customer", customer.Image);
                }
                _context.Customers.Remove(customer);
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
