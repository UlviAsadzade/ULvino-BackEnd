using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Areas.Manage.ViewModels;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            List<AppUser> admins = _userManager.Users.Where(x => x.IsAdmin == true).ToList();

            return View(admins);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(AdminViewModel adminVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser admin = await _userManager.FindByNameAsync(adminVM.UserName);

            if (admin != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            admin = await _userManager.FindByEmailAsync(adminVM.Email);
            if (admin != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }


            admin = new AppUser
            {
                FullName = adminVM.FullName,
                UserName = adminVM.UserName,
                Email = adminVM.Email,
                IsAdmin = true
            };

            var result = await _userManager.CreateAsync(admin, adminVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            await _userManager.AddToRoleAsync(admin, "Admin");
            await _signInManager.SignInAsync(admin, true);

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Delete(string id)
        {

            AppUser deleteAdmin = _userManager.Users.FirstOrDefault(x => x.Id == id && x.IsAdmin);

            await _userManager.DeleteAsync(deleteAdmin);

            await _userManager.UpdateAsync(deleteAdmin);

            return RedirectToAction("index");
        }
    }
}
