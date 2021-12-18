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
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            CheckoutViewModel checkoutVM = new CheckoutViewModel();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var productStr = HttpContext.Request.Cookies["Products"];

                if (!string.IsNullOrWhiteSpace(productStr))
                {
                    checkoutVM.BasketItemViewModels = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productStr);

                    foreach (var item in checkoutVM.BasketItemViewModels)
                    {
                        Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);

                        if (product != null)
                        {
                            item.Name = product.Name;
                            item.Price = product.SalePrice ;
                            item.Image = product.ProductImages.FirstOrDefault(x => x.IsPoster == true)?.Image;
                        }
                    }
                }
            }
            else
            {
                checkoutVM.Email = member.Email;
                checkoutVM.FullName = member.FullName;
                checkoutVM.Phone = member.PhoneNumber;

                checkoutVM.BasketItemViewModels = _context.BasketItems.Include(x => x.Product).Where(x => x.AppUserId == member.Id)
                                                   .Select(x => new BasketItemViewModel
                                                   {
                                                       ProductId = x.ProductId,
                                                       Name = x.Product.Name,
                                                       Count = x.Count,
                                                       Price = x.Product.SalePrice
                                                   }).ToList();

            }

            return View(checkoutVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutVM)
        {
            checkoutVM.BasketItemViewModels = _getBasketItems();

            if (!ModelState.IsValid) return View(checkoutVM);

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            Order order = new Order
            {
                FullName = checkoutVM.FullName,
                Email = checkoutVM.Email,
                Address = checkoutVM.Address,
                City = checkoutVM.City,
                Note = checkoutVM.Note,
                Phone = checkoutVM.Phone,
                Status = Models.Enums.OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow,
                OrderItems = new List<OrderItem>()
            };

            List<BasketItemViewModel> basketItemVMs = new List<BasketItemViewModel>();

            if (member == null)
            {
                var productStr = HttpContext.Request.Cookies["Products"];

                if (productStr != null)
                {
                    basketItemVMs = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productStr);
                }
            }
            else
            {
                order.AppUserId = member.Id;
                basketItemVMs = _context.BasketItems.Where(x => x.AppUserId == member.Id).Select(x => new BasketItemViewModel { ProductId = x.ProductId, Count = x.Count }).ToList();
            }

            foreach (var item in basketItemVMs)
            {
                Product product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);

                if (product == null)
                {
                    ModelState.AddModelError("", "Selected product not found");
                    return View(checkoutVM);
                }

                _addOrderItem(ref order, product, item.Count);
            }

            if (order.OrderItems.Count == 0)
            {
                ModelState.AddModelError("", "There is not any selected product!");
                return View(checkoutVM);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            if (member == null)
            {
                Response.Cookies.Delete("Products");
            }
            else
            {
                _context.BasketItems.RemoveRange(_context.BasketItems.Where(x => x.AppUserId == member.Id));
                _context.SaveChanges();
            }

            return RedirectToAction("index", "home");
        }


        private void _addOrderItem(ref Order order, Product product, int count)
        {
            OrderItem orderItem = new OrderItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                Count = count,
            };

            order.OrderItems.Add(orderItem);
            order.TotalAmount += orderItem.SalePrice  * orderItem.Count;
        }
        private List<BasketItemViewModel> _getBasketItems()
        {
            List<BasketItemViewModel> basketItems = new List<BasketItemViewModel>();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var productsStr = HttpContext.Request.Cookies["Products"];
                if (!string.IsNullOrWhiteSpace(productsStr))
                {
                    basketItems = JsonConvert.DeserializeObject<List<BasketItemViewModel>>(productsStr);

                    foreach (var item in basketItems)
                    {
                        Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
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

                basketItems = _context.BasketItems.Include(x => x.Product).Where(x => x.AppUserId == member.Id)
                                                    .Select(x => new BasketItemViewModel
                                                    {
                                                        ProductId = x.ProductId,
                                                        Name = x.Product.Name,
                                                        Count = x.Count,
                                                        Price = x.Product.SalePrice
                                                    }).ToList();

            }
            return basketItems;
        }
    }
}
