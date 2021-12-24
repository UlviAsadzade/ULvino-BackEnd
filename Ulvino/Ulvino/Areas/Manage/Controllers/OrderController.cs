using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;
using Ulvino.Services;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OrderController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            List<Order> orders = _context.Orders.Include(x => x.OrderItems).OrderByDescending(x=>x.CreatedAt).ToList();

            return View(orders);
        }

        public IActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("index", "error", new { area = "" });

            return View(order);
        }

        public IActionResult Accept(int id)
        {
            Order order = _context.Orders.Include(x=>x.OrderItems).Include(x=>x.AppUser).FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("index", "error", new { area = "" });

            order.Status = Models.Enums.OrderStatus.Accepted;

            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/order.html"))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{{total}}", order.TotalAmount.ToString());
            body = body.Replace("{{number}}", order.Id.ToString());
            body = body.Replace("{{adress}}", order.Address.ToString());
            body = body.Replace("{{date}}", order.CreatedAt.ToString("dd MMM yyyy HH:mm"));

            string orderItems = string.Empty;

            foreach (var item in order.OrderItems)
            {
                string tr = @$"<tr>
                     <td width=\""75 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {item.ProductName} </td>
                     <td width=\""25 %\"" align=\""left\"" style =\""font - family: Open Sans, Helvetica, Arial, sans-serif; font - size: 16px; font - weight: 400; line - height: 24px; padding: 15px 10px 5px 10px;\"" > {item.Count} x ${item.SalePrice}.00 </td>
                </tr>";

                orderItems += tr;
            }

            body = body.Replace("{{total}}", order.TotalAmount.ToString()).Replace("{{orderItems}}", orderItems).Replace("{{number}}", order.Id.ToString())
                       .Replace("{{adress}}", order.Address.ToString()).Replace("{{date}}", order.CreatedAt.ToString("dd MMM yyyy HH:mm"));

             
            _emailService.Send(order.AppUser.Email, "Order accepted", body);

            return RedirectToAction("index");
        }

        public IActionResult Reject(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("index", "error", new { area = "" });

            order.Status = Models.Enums.OrderStatus.Rejected;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
