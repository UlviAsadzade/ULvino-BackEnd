using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Helpers;
using Ulvino.Models;

namespace Ulvino.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            Setting settings = _context.Settings.FirstOrDefault();

            return View(settings);
        }


        public IActionResult Edit()
        {
            Setting setting = _context.Settings.FirstOrDefault();

            return View(setting);
        }

        [HttpPost]
        public IActionResult Edit(Setting setting)
        {

            Setting existSetting = _context.Settings.FirstOrDefault();
            if (existSetting == null) return RedirectToAction("index", "error", new { area = "" });

            if (!ModelState.IsValid) return View(existSetting);


            if (setting.HeaderLogoFile != null)
            {
                if (setting.HeaderLogoFile.ContentType != "image/png" && setting.HeaderLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HeaderLogoFile", "File type can be only jpeg,jpg or png!");
                    return View(existSetting);
                }

                if (setting.HeaderLogoFile.Length > 2097152)
                {
                    ModelState.AddModelError("HeaderLogoFile", "File size can not be more than 2MB!");
                    return View(existSetting);
                }

                if (existSetting.HeaderLogo != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.HeaderLogo);
                }

                string headerFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.HeaderLogoFile);

                existSetting.HeaderLogo = headerFileName;

            }
            else
            {
                if (setting.HeaderLogo == null)
                {
                    if (existSetting.HeaderLogo != null)
                    {
                        FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.HeaderLogo);
                        existSetting.HeaderLogo = null;
                    }
                }
            }



            if (setting.FooterLogoFile != null)
            {
                if (setting.FooterLogoFile.ContentType != "image/png" && setting.FooterLogoFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("FooterLogoFile", "File type can be only jpeg,jpg or png!");
                    return View(existSetting);
                }

                if (setting.FooterLogoFile.Length > 2097152)
                {
                    ModelState.AddModelError("FooterLogoFile", "File size can not be more than 2MB!");
                    return View(existSetting);
                }

                if (existSetting.FooterLogo != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.FooterLogo);
                }

                string footerFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.FooterLogoFile);

                existSetting.FooterLogo = footerFileName;

            }
            else
            {
                if (setting.FooterLogo == null)
                {
                    if (existSetting.FooterLogo != null)
                    {
                        FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.FooterLogo);
                        existSetting.FooterLogo = null;
                    }
                }
            }


            if (setting.HotlineFile != null)
            {
                if (setting.HotlineFile.ContentType != "image/png" && setting.HotlineFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HotlineFile", "File type can be only jpeg,jpg or png!");
                    return View(existSetting);
                }

                if (setting.HotlineFile.Length > 2097152)
                {
                    ModelState.AddModelError("HotlineFile", "File size can not be more than 2MB!");
                    return View(existSetting);
                }

                if (existSetting.HotlineImage != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.HotlineImage);
                }

                string phoneFileName = FileManager.Save(_env.WebRootPath, "uploads/setting", setting.HotlineFile);

                existSetting.HotlineImage = phoneFileName;

            }
            else
            {
                if (setting.HotlineImage == null)
                {
                    if (existSetting.HotlineImage != null)
                    {
                        FileManager.Delete(_env.WebRootPath, "uploads/setting", existSetting.HotlineImage);
                        existSetting.HotlineImage = null;
                    }
                }
            }

            existSetting.CustomerSubtitle = setting.CustomerSubtitle;
            existSetting.CustomerTitle = setting.CustomerTitle;
            existSetting.CustomerDesc = setting.CustomerDesc;
            existSetting.FooterDesc = setting.FooterDesc;
            existSetting.ContactEmail = setting.ContactEmail;
            existSetting.EmailIcon = setting.EmailIcon;
            existSetting.Address = setting.Address;
            existSetting.LocationIcon = setting.LocationIcon;
            existSetting.HomeIcon = setting.HomeIcon;
            existSetting.Phone = setting.Phone;
            existSetting.PhoneIcon = setting.PhoneIcon;
            existSetting.WorkTime = setting.WorkTime;
            existSetting.WorkTimeIcon = setting.WorkTimeIcon;
            existSetting.Hotline = setting.Hotline;
            existSetting.SupportEmail = setting.SupportEmail;
            existSetting.Adress2 = setting.Adress2;
            existSetting.TwitterIcon = setting.TwitterIcon;
            existSetting.TwitterUrl = setting.TwitterUrl;
            existSetting.FacebookIcon = setting.FacebookIcon;
            existSetting.FacebookUrl = setting.FacebookUrl;
            existSetting.YoutubeIcon = setting.YoutubeIcon;
            existSetting.YoutubeUrl = setting.YoutubeUrl;
            existSetting.GooglePlusIcon = setting.GooglePlusIcon;
            existSetting.GooglePlusUrl = setting.GooglePlusUrl;
            existSetting.PinterestIcon = setting.PinterestIcon;
            existSetting.PinterestUrl = setting.PinterestUrl;
            existSetting.ProcessDesc = setting.ProcessDesc;
            existSetting.MapUrl = setting.MapUrl;

            _context.SaveChanges();
            return RedirectToAction("index");
        }



    }
}
