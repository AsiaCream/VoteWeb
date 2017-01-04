using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Models
{
    public class Pictrue
    {
        /// <summary>
        /// 作者ID
        /// </summary>
        public long PictrueID { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 作品地址
        /// </summary>
        public string PictrueURL { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public long AuthorID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 作品简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 是否展示
        /// </summary>
        public int IsDisplay { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}
