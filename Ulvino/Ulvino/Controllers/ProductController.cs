using Microsoft.AspNetCore.Authorization;
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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;


        public ProductController(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;

        }

        public IActionResult Index(int page = 1, int? cheapPriceId=null, int? middlePriceId = null, int? expensivePriceId = null,
                                   int? oldYearsId = null, int? middleYearsId = null, int? newYearsId = null,
                                   int? regionId = null, int? typeId = null, int? variatyId = null, string search = null)
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
            if (!ModelState.IsValid)  return RedirectToAction("index", "error");

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

            ViewBag.SameProducts = _context.Products.Include(x => x.ProductImages).Where(x => x.Rate > 4).Take(4).ToList();


            Product product = _context.Products.Include(x => x.ProductImages).Include(x => x.Variaty).Include(x => x.Type)
                .Include(x => x.Region).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return RedirectToAction("index", "error");
            }

            List<Review> reviews = _context.Reviews.Include(x => x.AppUser).Where(x => x.IsAccepted && x.ProductId == id).ToList();

            ReviewViewModel reviewVM = new ReviewViewModel
            {
                Product = product,
                Reviews = reviews
            };

            return View(reviewVM);
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(int id, ReviewViewModel model)
        {

            Product product = _context.Products.Find(id);

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            if (model.Text.Length > 250)
            {
                ModelState.AddModelError("Text", "Your text is very length");
                return RedirectToAction("index", "error");
            }

            Review review = new Review
            {
                AppUserId = member.Id,
                ProductId = id,
                Rate = model.Rate,
                Text = model.Text,
                CreatedAt = DateTime.UtcNow
            };


            _context.Reviews.Add(review);

            await _context.SaveChangesAsync();

            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }


        public IActionResult AddToBasket(int id)
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

            return PartialView("_BasketPartial", products);
        }


        public IActionResult DeleteBasketItem(int id)
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
            return PartialView("_BasketPartial", products);
        }

        public IActionResult RemoveBasketItem(int id)
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
            return PartialView("_BasketPartial", products);
        }


        public IActionResult AddToWishlist(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            WishlistItemViewModel wishlistItem = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<WishlistItemViewModel> products = new List<WishlistItemViewModel>();

            if (member == null)
            {
                string productStr;

                if (HttpContext.Request.Cookies["Wishlist"] != null)
                {
                    productStr = HttpContext.Request.Cookies["Wishlist"];

                    products = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(productStr);

                    wishlistItem = products.FirstOrDefault(x => x.ProductId == id);
                }

                if (wishlistItem == null)
                {
                    wishlistItem = new WishlistItemViewModel
                    {
                        ProductId = product.Id,
                        Name = product.Name,
                        Image = product.ProductImages.FirstOrDefault(x => x.IsPoster == true).Image,
                        Price = (product.SalePrice),
                    };
                    products.Add(wishlistItem);
                }
                else
                {
                    products.Remove(wishlistItem);
                }
                productStr = JsonConvert.SerializeObject(products);

                HttpContext.Response.Cookies.Append("Wishlist", productStr);
            }
            else
            {
                WishlistItem memberWishlistItem = _context.WishlistItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);
                if (memberWishlistItem == null)
                {
                    memberWishlistItem = new WishlistItem
                    {
                        AppUserId = member.Id,
                        ProductId = id,

                    };
                    _context.WishlistItems.Add(memberWishlistItem);
                }
                else
                {
                    _context.WishlistItems.Remove(memberWishlistItem);
                }

                _context.SaveChanges();

                products = _context.WishlistItems.Include(x => x.Product).ThenInclude(bi => bi.ProductImages)
                    .Where(x => x.AppUserId == member.Id)
                    .Select(x => new WishlistItemViewModel
                    {
                        ProductId = x.ProductId,
                        Name = x.Product.Name,
                        Price = x.Product.SalePrice,
                        Image = x.Product.ProductImages.FirstOrDefault(b => b.IsPoster == true).Image
                    })
                    .ToList();
            }


            return RedirectToAction("index", "wishlist", products);
        }


        public IActionResult DeleteWishlistItem(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            WishlistItemViewModel wishlistItem = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<WishlistItemViewModel> products = new List<WishlistItemViewModel>();

            if (member == null)
            {

                string productStr = HttpContext.Request.Cookies["Wishlist"];

                products = JsonConvert.DeserializeObject<List<WishlistItemViewModel>>(productStr);

                wishlistItem = products.FirstOrDefault(x => x.ProductId == id);

                products.Remove(wishlistItem);

                productStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Wishlist", productStr);
            }

            else
            {
                WishlistItem memberWishlistItem = _context.WishlistItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                _context.WishlistItems.Remove(memberWishlistItem);

                _context.SaveChanges();

                products = _context.WishlistItems.Include(x => x.Product).ThenInclude(bi => bi.ProductImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new WishlistItemViewModel { ProductId = x.ProductId, Name = x.Product.Name, Price = x.Product.SalePrice, Image = x.Product.ProductImages.FirstOrDefault(b => b.IsPoster == true).Image }).ToList();

            }

            return RedirectToAction("index", "wishlist", products);
        }


    }
}
