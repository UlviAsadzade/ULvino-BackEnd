using Microsoft.AspNetCore.Authorization;
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
            if (!ModelState.IsValid) return RedirectToAction("index", "error");


            AppUser member = await _userManager.FindByNameAsync(registerVM.UserName);

            if (member != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return RedirectToAction("index", "error");

            }

            member = await _userManager.FindByEmailAsync(registerVM.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return RedirectToAction("index", "error");

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

                return RedirectToAction("index", "error");

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
                return RedirectToAction("index", "error");
            }

            var result = await _signInManager.PasswordSignInAsync(member, loginVM.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "username or password incorrect!");
                return RedirectToAction("index", "error");

            }

            return RedirectToAction("index", "home");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }


        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileViewModel profileVM = new ProfileViewModel
            {
                Email = member.Email,
                FullName = member.FullName,
                PhoneNumber = member.PhoneNumber,
                UserName = member.UserName,
                Orders = _context.Orders.Include(x=>x.OrderItems).Where(x => x.AppUserId == member.Id).ToList()
            };

            return View(profileVM);
        }


        [HttpPost]
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel profileVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!string.IsNullOrWhiteSpace(profileVM.ConfirmNewPassword) && !string.IsNullOrWhiteSpace(profileVM.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(member, profileVM.CurrentPassword, profileVM.NewPassword);

                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var item in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View();
                }

            }

            if (member.Email != profileVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == profileVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "This email has already been taken!");
                return View();
            }

            member.FullName = profileVM.FullName;
            member.Email = profileVM.Email;
            member.PhoneNumber = profileVM.PhoneNumber;


            var result = await _userManager.UpdateAsync(member);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

            return RedirectToAction("profile");
        }
    }
}
