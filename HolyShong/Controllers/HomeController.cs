﻿using HolyShong.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolyShong.Models.HolyShongModel;
using HolyShong.ViewModels;

namespace HolyShong.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiscountService _discountService;
        private readonly StoreCategoryService _storecategoryService;
        private readonly StoreService _storeService;
        public HomeController()
        {
            _discountService = new DiscountService();
            _storecategoryService = new StoreCategoryService();
            _storeService = new StoreService();
        }
        //初始

        public ActionResult Index()//首頁
        {
            var result = new HomeViewModel()
            {
                StoreCategories = new List<HomeStoreCategory>(),
                NumberArray = new int[5]
            };

            result = _storeService.GetAllStores(1);
            result.StoreCategories = _storecategoryService.GetAllStoreCategories();
            result.NumberArray = _storecategoryService.GetRandomNumber();
            return View(result);
        }

        public ActionResult StoreCategorySearch(int? id)//主分類搜尋
        {
            if (!id.HasValue)
            {
                return RedirectToAction("NoSearch");
            }
            var result = _storeService.GetAllStoresByStoreCategoryId(id.Value);
            return View(result);
        }

        public ActionResult NoSearch()//搜尋不到頁面
        {
            return View();
        }


        //Todo 顯示更多餐廳按鈕需導入Search頁面
        [HttpGet]
        public ActionResult Search(SearchRequest input)//搜尋頁面
        {
            input.Keyword = string.IsNullOrEmpty(input.Keyword) ? string.Empty : input.Keyword;
            //input.Price = string.IsNullOrEmpty(input.Price) ? string.Empty : input.Price;

            var result = _storeService.GetAllStoresByRequest(input);

            //轉換其它頁面
            if (result.StoreCards.Count == 0)
            {
                return View("NoSearch");
            }

            input.SearchCount = result.StoreCards.Count;
            ViewBag.searchTemp = Newtonsoft.Json.JsonConvert.SerializeObject(input);
            return View(result);
        }

        public void AcquireDiscount(string discountName)
        {
            _discountService.AcquireDiscount(discountName);
        }
    }
}