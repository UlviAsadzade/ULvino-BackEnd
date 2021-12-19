using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;
using Ulvino.ViewModels;

namespace Ulvino.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public WishlistController(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
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

                    foreach (var item in items)
                    {
                        Product product = _context.Products.Include(c => c.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);

                        if (product != null)
                        {
                            item.Name = product.Name;
                            item.Price = product.SalePrice;
                            item.Image = product.ProductImages.FirstOrDefault(x => x.IsPoster == true)?.Image;
                        }
                    }
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

            return View(items);
        }
    }
}
