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
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<BasketItemViewModel> items = new List<BasketItemViewModel>();

            AppUser member = null;

            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }


            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Products"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(itemsStr);

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
                List<BasketItem> basketItems = _context.BasketItems.Include(x => x.Product).ThenInclude(x => x.ProductImages).Where(x => x.AppUserId == member.Id).ToList();
               
                items = basketItems.Select(x => new BasketItemViewModel
                {
                    ProductId = x.ProductId,
                    Count = x.Count,
                    Image = x.Product.ProductImages.FirstOrDefault(bi => bi.IsPoster == true)?.Image,
                    Name = x.Product.Name,
                    Price = x.Product.SalePrice
                }).ToList();
            }

            return View(items);
        }

        public IActionResult AddToCart(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            BasketItemViewModel basketItem = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<BasketItemViewModel> products = new List<BasketItemViewModel>();

            if (member == null)
            {
                string productsStr;

                if (HttpContext.Request.Cookies["Products"] != null)
                {
                    productsStr = HttpContext.Request.Cookies["Products"];
                    products = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);

                    basketItem = products.FirstOrDefault(x => x.ProductId == id);
                }

                if (basketItem == null)
                {
                    basketItem = new BasketItemViewModel
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Image = product.ProductImages.FirstOrDefault(x => x.IsPoster == true).Image,
                        Price = product.SalePrice,
                        Count = 1
                    };
                    products.Add(basketItem);
                }
                else
                {
                    basketItem.Count++;
                }
                productsStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Products", productsStr);
            }
            else
            {
                BasketItem memberBasketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                if (memberBasketItem == null)
                {
                    memberBasketItem = new BasketItem
                    {
                        AppUserId = member.Id,
                        ProductId = id,
                        Count = 1
                    };
                    _context.BasketItems.Add(memberBasketItem);
                }
                else
                {
                    memberBasketItem.Count++;
                }
                _context.SaveChanges();

                products = _context.BasketItems.Include(x => x.Product).ThenInclude(pi => pi.ProductImages)
                    .Where(x => x.AppUserId == member.Id)
                    .Select(x => new BasketItemViewModel
                    {
                        ProductId = x.ProductId,
                        Count = x.Count,
                        Name = x.Product.Name,
                        Price = x.Product.SalePrice,
                        Image = x.Product.ProductImages.FirstOrDefault(b => b.IsPoster == true).Image
                    })
                    .ToList();
            }

            return RedirectToAction("index", "cart", products);
        }


        public IActionResult DeleteCartItem(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            BasketItemViewModel basketItem = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<BasketItemViewModel> products = new List<BasketItemViewModel>();

            if (member == null)
            {

                string productStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productStr);

                basketItem = products.FirstOrDefault(x => x.ProductId == id);


                if (basketItem.Count == 1)
                {

                    basketItem.Count = 1;
                }
                else
                {
                    basketItem.Count--;
                }
                productStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Products", productStr);
            }

            else
            {
                BasketItem memberBasketItem = _context.BasketItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                if (memberBasketItem.Count == 1)
                {

                    memberBasketItem.Count = 1;
                }
                else
                {
                    memberBasketItem.Count--;
                }

                _context.SaveChanges();

                products = _context.BasketItems.Include(x => x.Product).ThenInclude(pi => pi.ProductImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new BasketItemViewModel
                    {
                        ProductId = x.ProductId,
                        Count = x.Count,
                        Name = x.Product.Name,
                        Price = x.Product.SalePrice,
                        Image = x.Product.ProductImages.FirstOrDefault(b => b.IsPoster == true).Image
                    })
                    .ToList();

            }

            return RedirectToAction("index", "cart", products);
        }


        public IActionResult RemoveCartItem(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            BasketItemViewModel basketItem = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<BasketItemViewModel> products = new List<BasketItemViewModel>();

            if (member == null)
            {

                string productStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productStr);

                basketItem = products.FirstOrDefault(x => x.ProductId == id);

                products.Remove(basketItem);

                productStr = JsonConvert.SerializeObject(products);

                HttpContext.Response.Cookies.Append("Products", productStr);
            }

            else
            {
                BasketItem memberBasketItem = _context.BasketItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                _context.BasketItems.Remove(memberBasketItem);

                _context.SaveChanges();

                products = _context.BasketItems.Include(x => x.Product).ThenInclude(pi => pi.ProductImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new BasketItemViewModel
                    {
                        ProductId = x.ProductId,
                        Count = x.Count,
                        Name = x.Product.Name,
                        Price = x.Product.SalePrice,
                        Image = x.Product.ProductImages.FirstOrDefault(b => b.IsPoster == true).Image
                    })
                    .ToList();

            }

            return RedirectToAction("index", "cart", products);
        }
    }
}
