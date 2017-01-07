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
        public List<Picture> Pictures{get;set;}

        /// <summary>
        /// 投票总排行前10的作品
        /// </summary>
        public List<Picture> Top10Pictures{get;set;}
    }
}