﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolyShong.ViewModels;
using HolyShong.Models.HolyShongModel;
using HolyShong.Repositories;

namespace HolyShong.Services
{
    public class StoreService
    {
        //初始
        private readonly HolyShongRepository _repo;
        public StoreService()
        {
            _repo = new HolyShongRepository();

        }
        //店家卡片

        public HomeViewModel GetAllStores()
        {
            var result = new HomeViewModel
            {
                StoreCardBlocks = new List<StoreCardBlock>()
            };


            //1.找出所有商店類別(不用做)
            var storecategories = _repo.GetAll<Models.HolyShongModel.StoreCategory>().ToList();
            //2.找出所有類別下面的所有店家
            var stores = _repo.GetAll<Store>().ToList();
            //3.依商店類別將店家分類後再全部取出
            foreach (var item in storecategories)
            {
                //這個類別的商店全部挑出來
                var temp = stores.Where(x => x.StoreCategoryId == item.StoreCategoryId);
                //存成StoreCards
                var cards = new List<StoreCard>();
                foreach (var store in temp)
                {
                    var card = new StoreCard
                    {
                        StoreId = store.StoreId,
                        StoreImg = store.Img,
                        StoreName = store.Name
                    };
                    cards.Add(card);
                }
                var block = new StoreCardBlock
                {
                    StoreCategoryId = item.StoreCategoryId,
                    StoreCategoryImg = item.Img,
                    StoreCategoryName = item.Name,
                    StoreCards = cards
                };
                result.StoreCardBlocks.Add(block);
            }
            return result;
        }

        public StoreCategorySearchViewModel GetAllStoresByStoreCategoryId(int storecategoryId)
        {
            var result = new StoreCategorySearchViewModel
            {
                StoreCards = new List<StoreCard>()
            };
            //1.找到特定的StoreCategory
            var storecategory = _repo.GetAll<Models.HolyShongModel.StoreCategory>().FirstOrDefault(x => x.StoreCategoryId == storecategoryId);

            if (storecategory == null)
            {
                //沒找到
            }
            //2.找到這個StoreVategory的所有Store
            var stores = _repo.GetAll<Store>().Where(x => x.StoreCategoryId == storecategoryId).ToList();
            var cards = new List<StoreCard>();
            foreach (var item in stores)
            {
                var temp = new StoreCard()
                {
                    StoreId = item.StoreId,
                    StoreImg = item.Img,
                    StoreName = item.Name
                };
                cards.Add(temp);
            }
            result.StoreCategoryId = storecategory.StoreCategoryId;
            result.StoreCategoryName = storecategory.Name;
            result.StoreCards = cards;
            return result;
        }

        public SearchViewModel GetAllStoresByKeyword(string keyword)
        {
            var result = new SearchViewModel
            {
                StoreCards = new List<StoreCard>()
            };
            var stores = _repo.GetAll<Store>().Where(x => x.KeyWord.Contains(keyword)).ToList();
            if (stores.Count == 0)
            {
                return result;
            }

            var cards = new List<StoreCard>();
            foreach (var item in stores)
            {
                var temp = new StoreCard()
                {
                    StoreId = item.StoreId,
                    StoreImg = item.Img,
                    StoreName = item.Name
                };
                cards.Add(temp);
            }
            result.StoreCards = cards;
            return result;
        }

        public SearchViewModel GetAllStoresBySearchRequest(SearchRequest input)
        {
            //參數初始設定
            var result = new SearchViewModel
            {
                StoreCards = new List<StoreCard>()
            };


            //1.找出所有商店
            var stores = _repo.GetAll<Store>().ToList();


            //2.找出所有產品類別
            var allProductCategories = _repo.GetAll<ProductCategory>().ToList();

            //3.找出所有商店下面的所有產品
            var allProducts = _repo.GetAll<Product>().ToList();
            var productList = new List<Product>();

            //4.找出所有商店的產品平均價格

            //4.1找出每家店
            foreach (var item in stores)
            {
                var productAveragePriceList = new List<decimal>();
                //4.1找出每家店本身的產品類別
                var productCategoryList = allProductCategories.Where(x => x.StoreId == item.StoreId).ToList();
                //4.2找出每個產品類別下面的所有產品的平均價格
                foreach (var productCategory in productCategoryList)
                {
                    productList = allProducts.Where(x => x.ProductCategoryId == productCategory.ProductCategoryId).ToList();
                    var productAveragePrice = productList.Select(x => x.UnitPrice).ToList().Average();
                    productAveragePriceList.Add(productAveragePrice);
                }

                decimal storeAveragePrice = productAveragePriceList.Average();
            }


            //5.依商店將後再全部取出
            foreach (var item in stores)
            {

                //這個商店的產品全部挑出來
                var temp = stores.Where(x => x.KeyWord.Contains(input.Keyword));
                ////存成StoreCards
                var cards = new List<StoreCard>();

                var productAveragePriceList = new List<decimal>();

                //4.1找出每家店本身的產品類別
                var productCategoryList = allProductCategories.Where(x => x.StoreId == item.StoreId).ToList();
                //4.2找出每個產品類別下面的所有產品的平均價格
                foreach (var productCategory in productCategoryList)
                {
                    productList = allProducts.Where(x => x.ProductCategoryId == productCategory.ProductCategoryId).ToList();
                    var productAveragePrice = productList.Select(x => x.UnitPrice).ToList().Average();
                    productAveragePriceList.Add(productAveragePrice);
                }
                foreach (var store in temp)
                {
                    var card = new StoreCard
                    {
                        StoreId = store.StoreId,
                        StoreImg = store.Img,
                        StoreName = store.Name,
                        StoreAveragePrice = productAveragePriceList.Average()
                    };
                    cards.Add(card);
                }
            }
            return result;
        }
    }
}