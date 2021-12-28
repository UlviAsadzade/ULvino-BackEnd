using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Wishlists = null;

            List<WishlistItemViewModel> items = new List<WishlistItemViewModel>();

            AppUser member = null;

            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Wishlist"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(itemsStr);
                    
                }
            }
            else
            {
                List<WishlistItem> wishlistItems = _context.WishlistItems.Include(x => x.Product).ThenInclude(x => x.ProductImages).Where(x => x.AppUserId == member.Id).ToList();
                items = wishlistItems.Select(x => new WishlistItemViewModel
                {
                    ProductId = x.ProductId,
                    Image = x.Product.ProductImages.FirstOrDefault(bi => bi.IsPoster == true)?.Image,
                    Name = x.Product.Name,
                    Price = x.Product.SalePrice
                }).ToList();
            }

            ViewBag.Wishlists = items;

            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders = _context.Sliders.ToList(),
                Blogs = _context.Blogs.Take(4).ToList(),
                FeaturedProducts = _context.Products.Include(x=>x.ProductImages).Where(x=>x.IsFeatured).Take(8).ToList(),
                PopularProducts = _context.Products.Include(x=>x.ProductImages).Where(x=>x.Rate>4).Take(8).ToList(),
                Customers = _context.Customers.ToList(),
                Reviews = _context.Reviews.Include(x => x.AppUser).ToList(),
                Settings = _context.Settings.FirstOrDefault()
            };

            return View(homeVM);
        }


        public IActionResult GetProduct(int id)
        {
            Product product = _context.Products
                .Include(x => x.ProductImages).Include(x => x.Variaty)
                .Include(x => x.Type)
                .Include(x => x.Region)
                .FirstOrDefault(x => x.Id == id);

            return PartialView("_ProductModalPartial", product);
        }


        public IActionResult Search(string search)
        {
            var query = _context.Products.Include(x=>x.ProductImages).AsQueryable().Where(x => x.Name.Contains(search));

            List<Product> products = query.OrderByDescending(x => x.Id).ToList();

            return PartialView("_SearchPartial", products);
        }


    }
}
