using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;

namespace VoteWeb.ViewModels.Admin
{
    public class PictureCListViewModel
    {
        /// <summary>
        /// 作品信息
        /// </summary>
        public List<Picture> Pictures{get;set;}
        /// <summary>
        /// 分类信息
        /// </summary>
        public Category category{get;set;}
    }
}
