﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyShong.ViewModels
{
          
    public class HolyCartViewModel
    {
        /// <summary>
        /// cart
        /// </summary>
        public int CartId { get; set; }
        /// <summary>
        /// store
        /// </summary>
        public string StoreName { get; set; }
        public List<CartItem> CartItems { get; set; }
        /// <summary>
        /// item X product
        /// </summary>
        public decimal TotalPrice { get; set; }
    }

    public class CartItem
    {   
        /// <summary>
        /// item
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// product
        /// </summary>
        public string ProductName { get; set; }
        public List<ProductOptionCard> ProductOptionCards { get; set; }
        /// <summary>
        /// product
        /// </summary>
        public decimal UnitPrice { get; set; }
       
    }
    public class ProductOptionCard
    {   
        /// <summary>
        /// productOption
        /// </summary>
        public int? ProductOptionId { get; set; }
        /// <summary>
        /// 甜度選擇 productOption
        /// </summary>
        public string ProductOptionName { get; set; }
        /// <summary>
        /// 無糖或少糖 
        /// </summary>
        public string ProductOptionDetail { get; set; }
        /// <summary>
        /// 加價 productOptionDetail
        /// </summary>
        public decimal? addPrice { get; set; }
    }


}