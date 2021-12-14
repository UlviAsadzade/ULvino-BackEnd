using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;
using Ulvino.ViewModels;

namespace Ulvino.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int? cheapPriceId=null, int? middlePriceId = null, int? expensivePriceId = null,
                                   int? oldYearsId = null, int? middleYearsId = null, int? newYearsId = null,
                                   int? regionId = null, int? typeId = null, int? variatyId = null, string search = null)
        {

            var query = _context.Products.AsQueryable();

            ViewBag.CurrentRegionId = regionId;
            ViewBag.CurrentTypeId = typeId;
            ViewBag.CurrentVariatyId = variatyId;
            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search));

            if (regionId != null)
                query = query.Where(x => x.RegionId == regionId);


            if (typeId != null)
                query = query.Where(x => x.TypeId == typeId);

            if (variatyId != null)
                query = query.Where(x => x.VariatyId == variatyId);

            if (cheapPriceId != null)
                query = query.Where(x => x.SalePrice<=100);

            if (middlePriceId != null)
                query = query.Where(x => x.SalePrice > 100 && x.SalePrice<300);

            if (expensivePriceId != null)
                query = query.Where(x => x.SalePrice >= 300);

            if (oldYearsId != null)
                query = query.Where(x => x.Vintage.Year <= 1900);

            if (middleYearsId != null)
                query = query.Where(x => x.Vintage.Year > 1900 && x.Vintage.Year < 1991);

            if (newYearsId != null)
                query = query.Where(x => x.Vintage.Year >= 1991);


            ProductViewModel productVM = new ProductViewModel
            {
                Variaties = _context.Variaties.Include(x=>x.Products).ToList(),
                Types = _context.Types.Include(x=>x.Products).ToList(),
                Regions = _context.Regions.Include(x=>x.Products).ToList(),
                Products = query.Include(x=>x.ProductImages).Skip((page - 1) * 9).Take(9).ToList()
            };

            ViewBag.SelectedPage = page;
            ViewBag.TotalPage = Math.Ceiling(query.Count() / 9m);

            return View(productVM);
        }

        public IActionResult Detail(int id)
        {
            if (!ModelState.IsValid) return View();

            Product product = _context.Products.Include(x => x.ProductImages).Include(x => x.Variaty).Include(x => x.Type)
                .Include(x => x.Region).FirstOrDefault(x => x.Id == id);

            ViewBag.SameProducts = _context.Products.Include(x => x.ProductImages).Where(x => x.Rate > 4).Take(4).ToList();

            return View(product);
        }
    }
}
