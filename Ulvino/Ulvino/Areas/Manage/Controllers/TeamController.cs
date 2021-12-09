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

    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Team> teams = _context.Teams.ToList();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Team team)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType != "image/jpeg" && team.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/team", team.ImageFile);

                team.Image = fileName;
            }

            _context.Teams.Add(team);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return RedirectToAction("index", "error", new { area = "" });

            return View(team);
        }


        [HttpPost]
        public IActionResult Edit(Team team)
        {
            if (!ModelState.IsValid) return View();

            Team existTeam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);

            if (existTeam == null) return RedirectToAction("index", "error", new { area = "" });

            string fileName = null;
            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                fileName = FileManager.Save(_env.WebRootPath, "uploads/team", team.ImageFile);
            }

            if (fileName != null || team.Image == null)
            {
                if (existTeam.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/team", existTeam.Image);
                }

                existTeam.Image = fileName;
            }

            existTeam.FullName = team.FullName;
            existTeam.Profession = team.Profession;
            existTeam.FacebookUrl = team.FacebookUrl;
            existTeam.TwitterUrl = team.TwitterUrl;
            existTeam.GooglePlusUrl = team.GooglePlusUrl;
            existTeam.PinterestUrl = team.PinterestUrl;


            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return Json(new { status = 404 });

            try
            {
                if (team.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/team", team.Image);
                }
                _context.Teams.Remove(team);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
