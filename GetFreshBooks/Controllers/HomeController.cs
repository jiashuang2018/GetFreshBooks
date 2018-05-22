﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetFreshBooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Categories = BusinessLogic.GetAllCategories;
            ViewBag.Books = BusinessLogic.GetAllBooks;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string isbn)
        {
            System.Diagnostics.Debug.WriteLine(isbn);
            BusinessLogic.AddToCart(isbn);
            ViewBag.Categories = BusinessLogic.GetAllCategories;
            ViewBag.Books = BusinessLogic.GetAllBooks;
            return View("Index");         
        }

        [Authorize(Roles ="User,Admin")]
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