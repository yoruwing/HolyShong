﻿using HolyShong.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolyShong.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiscountService _discountService;
        public HomeController()
        {
            _discountService = new DiscountService();
        }
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Search()
        {
            return View();
        }


        public ActionResult NoSearch()
        {            
            return View();
        }

        public void AcquireDiscount(string discountName)
        {
            _discountService.AcquireDiscount(discountName);
        }
    }
}