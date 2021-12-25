using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(x=>x.Type).Include(x=>x.Variaty).Include(x=>x.ProductImages).ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Regions = _context.Regions.ToList();
            ViewBag.Variaties = _context.Variaties.ToList();
            ViewBag.Types = _context.Types.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Regions = _context.Regions.ToList();
            ViewBag.Variaties = _context.Variaties.ToList();
            ViewBag.Types = _context.Types.ToList();

            if (!_context.Regions.Any(x => x.Id == product.RegionId)) ModelState.AddModelError("RegionId", "Region not found!");
            if (!_context.Variaties.Any(x => x.Id == product.VariatyId)) ModelState.AddModelError("VariatyId", "Variaty not found!");
            if (!_context.Types.Any(x => x.Id == product.TypeId)) ModelState.AddModelError("TypeId", "Type not found!");


            if (!ModelState.IsValid) return View();

            product.ProductImages = new List<ProductImage>();

            if (product.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
                return View();
            }
            else
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                string newPosterName = FileManager.Save(_env.WebRootPath, "uploads/product", product.PosterFile);

                ProductImage poster = new ProductImage
                {
                    Image = newPosterName,
                    IsPoster = true,
                };
                product.ProductImages.Add(poster);
            }



            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    string newFileName = FileManager.Save(_env.WebRootPath, "uploads/product", file);

                    ProductImage image = new ProductImage
                    {
                        IsPoster = false,
                        Image = newFileName
                    };

                    product.ProductImages.Add(image);
                }
            }


            if (product.Rate < 0)
            {
                ModelState.AddModelError("Rate", "Rate count can not be less than 0");
                return View();
            }

            if (product.CostPrice < 0)
            {
                ModelState.AddModelError("CostPrice", "CostPrice count can not be less than 0");
                return View();
            }

            if (product.SalePrice < 0)
            {
                ModelState.AddModelError("SalePrice", "SalePrice count can not be less than 0");
                return View();
            }


            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            if (product == null) return RedirectToAction("index", "error", new { area = "" });

            ViewBag.Regions = _context.Regions.ToList();
            ViewBag.Variaties = _context.Variaties.ToList();
            ViewBag.Types = _context.Types.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (!_context.Regions.Any(x => x.Id == product.RegionId)) ModelState.AddModelError("RegionId", "Region not found!");
            if (!_context.Variaties.Any(x => x.Id == product.VariatyId)) ModelState.AddModelError("VariatyId", "Variaty not found!");
            if (!_context.Types.Any(x => x.Id == product.TypeId)) ModelState.AddModelError("TypeId", "Type not found!");


            if (!ModelState.IsValid) return View();

            Product existProduct = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == product.Id);

            if (existProduct == null) return RedirectToAction("index", "error", new { area = "" });


            if (product.PosterFile != null)
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                ProductImage poster = existProduct.ProductImages.FirstOrDefault(x => x.IsPoster == true);

                string newPosterName = FileManager.Save(_env.WebRootPath, "uploads/product", product.PosterFile);

                if (poster == null)
                {
                    poster = new ProductImage
                    {
                        IsPoster = true,
                        Image = newPosterName,
                        ProductId = product.Id
                    };

                    _context.ProductImages.Add(poster);
                }
                else
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/product", poster.Image);
                    poster.Image = newPosterName;
                }
            }

            List<ProductImage> removablePhotos = existProduct.ProductImages.Where(x => x.IsPoster == false && !product.ProductImageIds.Contains(x.Id)).ToList();

            foreach (var item in removablePhotos)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/product", item.Image);
            }

            existProduct.ProductImages.RemoveAll(x => x.IsPoster == false && !product.ProductImageIds.Contains(x.Id));

            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    string newFileName = FileManager.Save(_env.WebRootPath, "uploads/product", file);

                    ProductImage image = new ProductImage
                    {
                        IsPoster = false,
                        Image = newFileName
                    };

                    existProduct.ProductImages.Add(image);
                }
            }


            if (product.Rate < 0)
            {
                return RedirectToAction("index", "error", new { area = "" });

            }

            if (product.CostPrice < 0)
            {
                return RedirectToAction("index", "error", new { area = "" });

            }

            if (product.SalePrice < 0)
            {
                return RedirectToAction("index", "error", new { area = "" });

            }
           

            existProduct.Name = product.Name;
            existProduct.VariatyId = product.VariatyId;
            existProduct.TypeId = product.TypeId;
            existProduct.RegionId = product.RegionId;
            existProduct.SalePrice = product.SalePrice;
            existProduct.CostPrice = product.CostPrice;
            existProduct.IsFeatured = product.IsFeatured;
            existProduct.Rate = product.Rate;
            existProduct.Desc = product.Desc;
            existProduct.Vintage = product.Vintage;


            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return Json(new { status = 404 });

            try
            {
                _context.Products.Remove(product);
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
