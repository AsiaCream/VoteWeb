using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;

namespace VoteWeb.ViewModels
{
    public class HomeListViewModel
    {
        /// <summary>
        /// 分类下最新作品列表
        /// </summary>
        public List<Picture> Pictures { get; set; }

        /// <summary>
        /// 该分类前十条
        /// </summary>
        public List<Picture> Top10Pictures { get; set; }
        /// <summary>
        /// 随机列表
        /// </summary>
        public List<Picture> RandomPictures { get; set; }
    }
}
