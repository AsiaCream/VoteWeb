using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;

namespace VoteWeb.ViewModels.Admin
{
    public class SearchListViewModel
    {
        /// <summary>
        /// 作者名
        /// </summary>
        public List<Author> authors { get; set; }

        /// <summary>
        /// 分类名
        /// </summary>
        public List<Category> categorys { get; set; }

        /// <summary>
        /// 作品
        /// </summary>
        public List<Picture> pictures { get; set; }

        /// <summary>
        /// 当前关键字
        /// </summary>
        public string keyword { get; set; }
    }
}
