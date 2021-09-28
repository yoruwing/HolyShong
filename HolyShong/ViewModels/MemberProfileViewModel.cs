﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolyShong.ViewModels
{
    public class MemberProfileViewModel
    {
        /// <summary>
        /// 會員編號
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 會員姓氏
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 會員名字
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 會員手機
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// 會員郵遞區號
        /// </summary>
        public int Zipcode { get; set; }
        /// <summary>
        /// 會員地址
        /// 對應Address表
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 送送會員
        /// 對應Rank表
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// 會員信箱
        /// </summary>
        public string Email { get; set; }

        public string ShowPrimary()
        {
            if (IsPrimary)
                return "送送會員";
            else return "一般會員";

        }
    }
}