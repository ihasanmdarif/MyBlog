﻿using MyBlog.Models;
using MyBlog.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();

        public ActionResult Index()
        {
            bool IsAdmin = User.IsInRole("Admin");

            var model = DbContext.Posts
                .Where(p => (IsAdmin ? true : p.Published))
                .Select(p => new ListAllPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Body = p.Body,
                    AuthorName = p.Author,
                    MediaUrl = p.MediaUrl,
                    Created = p.DateCreated,
                    Updated = p.DateUpdated,
                    Published = p.Published,
                    Slug = p.Slug,
                }).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}