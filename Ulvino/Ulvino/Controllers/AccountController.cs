using Microsoft.AspNetCore.Identity;
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
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            MemberRegisterViewModel memberRegisterVM = new MemberRegisterViewModel { };

            return PartialView("_RegisterModalPartial", memberRegisterVM);
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPost(MemberRegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return RedirectToAction("index", "error", new { area = "manage" });


            AppUser member = await _userManager.FindByNameAsync(registerVM.UserName);

            if (member != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return RedirectToAction("index", "error", new { area = "manage" });

            }

            member = await _userManager.FindByEmailAsync(registerVM.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return RedirectToAction("index", "error", new { area = "manage" });

            }

            member = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return RedirectToAction("index", "error", new { area = "manage" });

            }

            await _userManager.AddToRoleAsync(member, "Member");
            await _signInManager.SignInAsync(member, true);

            return RedirectToAction("index", "home");
        }


        public IActionResult Login()
        {
            MemberLoginViewModel memberLoginVM = new MemberLoginViewModel { };

            return PartialView("_LoginModalPartial", memberLoginVM);
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginPost (MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginVM.UserName && !x.IsAdmin);

            if (member == null)
            {
                ModelState.AddModelError("", "username or password incorrect!");
                return RedirectToAction("index", "error", new { area = "manage" });
            }

            var result = await _signInManager.PasswordSignInAsync(member, loginVM.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "username or password incorrect!");
                return RedirectToAction("index", "error", new { area = "manage" });

            }

            return RedirectToAction("index", "home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }
    }
}
