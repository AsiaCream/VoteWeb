using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;

namespace VoteWeb.ViewModels
{
    public class HomeDetailViewModel
    {
        /// <summary>
        /// 作品实体
        /// </summary>
        public Picture picture { get; set; }
        /// <summary>
        /// 最新作品
        /// </summary>
        public List<Picture> NewPictures { get; set; }
        /// <summary>
        /// 相似作品
        /// </summary>
        public List<Picture> SimilarPictures { get; set; }
    }
}
