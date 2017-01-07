using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;

namespace VoteWeb.ViewModels.Admin
{
    public class PictureListViewModel
    {
        /// <summary>
        /// 作品信息
        /// </summary>
        public List<Picture> Pictures{get;set;}
        /// <summary>
        /// 作者信息
        /// </summary>
        public Author author{get;set;}
    }
}
