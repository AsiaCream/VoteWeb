using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;

namespace VoteWeb.ViewModels
{
    public class HomeIndexViewModel
    {
        /// <summary>
        /// 最新的前20张
        /// </summary>
        public Pictrue Pictrues{get;set;}

        /// <summary>
        /// 投票总排行前10的作品
        /// </summary>
        public Pictrue Top10Pictrues{get;set;}
    }
}