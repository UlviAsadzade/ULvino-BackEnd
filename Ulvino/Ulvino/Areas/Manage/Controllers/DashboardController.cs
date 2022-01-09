using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Areas.Manage.ViewModels;
using Ulvino.Models;
using Ulvino.Models.Enums;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]


    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DashboardViewModel dashboardVM = new DashboardViewModel
            {
                AcceptedOrders = _context.Orders.Where(x=>x.Status == OrderStatus.Accepted).Include(x => x.OrderItems).ToList(),
                PendingOrders = _context.Orders.Where(x=>x.Status == OrderStatus.Pending).Include(x => x.OrderItems).ToList(),
                Users = _context.AppUsers.Where(x => x.IsAdmin == false).ToList(),
                LatestOrders = _context.Orders.OrderByDescending(x => x.CreatedAt).Take(5).ToList(),
                RedWines = _context.Products.Where(x => x.Type.Name == "Red").Count(),
                WhiteWines = _context.Products.Where(x => x.Type.Name == "White").Count(),
                RoseWines = _context.Products.Where(x => x.Type.Name == "Rose").Count(),
                SaturdayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 1 && x.Status == OrderStatus.Accepted).Count(),
                SaturdayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 1 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount),
                SundayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 2 && x.Status == OrderStatus.Accepted).Count(),
                SundayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 2 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount),
                MondayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 3 && x.Status == OrderStatus.Accepted).Count(),
                MondayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 3 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount),
                TuesdayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 4 && x.Status == OrderStatus.Accepted).Count(),
                TuesdayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 4 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount),
                WednesdayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 5 && x.Status == OrderStatus.Accepted).Count(),
                WednesdayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 5 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount),
                ThursdayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 6 && x.Status == OrderStatus.Accepted).Count(),
                ThursdayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 6 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount),
                FridayOrders = _context.Orders.Where(x => x.CreatedAt.Day == 7 && x.Status == OrderStatus.Accepted).Count(),
                FridayIncome = _context.Orders.Where(x => x.CreatedAt.Day == 7 && x.Status == OrderStatus.Accepted).Sum(x => x.TotalAmount)
                
            };

            double redWinesCount = _context.Products.Where(x => x.Type.Name == "Red").Count();
            double whiteWinesCount = _context.Products.Where(x => x.Type.Name == "White").Count();
            double roseWinesCount = _context.Products.Where(x => x.Type.Name == "Rose").Count();
            double totalCount = _context.Products.Count();
            ViewBag.RedWinesPercent = Math.Ceiling(redWinesCount / totalCount * 100);
            ViewBag.WhiteWinesPercent = Math.Ceiling(whiteWinesCount / totalCount * 100);
            ViewBag.RoseWinesPercent = Math.Ceiling(roseWinesCount / totalCount * 100);

            double weeklyIncome = 0;
            List<Order> orders = _context.Orders.Where(x => x.CreatedAt.Day >= 1 && x.CreatedAt.Day <= 7 && x.Status == OrderStatus.Accepted).Include(x => x.OrderItems).ToList();
            foreach (var item in orders )
            {
                weeklyIncome += (item.OrderItems.Sum(x => x.SalePrice * x.Count) - item.OrderItems.Sum(x => x.CostPrice * x.Count));
            }

            ViewBag.WeeklyOrders = _context.Orders.Where(x => x.CreatedAt.Day >= 1 && x.CreatedAt.Day <= 7 && x.Status == OrderStatus.Accepted).Count();
            ViewBag.WeeklyIncome = weeklyIncome;

            return View(dashboardVM);
        }
    }
}
