using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Models
{
    public class Photo
    {
        /// <summary>
        /// 作品ID
        /// </summary>
        public long PhotoID { get; set; }
        /// <summary>
        /// 作品标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public long AuthorID { get; set; }
        /// <summary>
        /// 作品URL
        /// </summary>
        public string PhotoURL { get; set; }
        /// <summary>
        /// 作品简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 是否已经删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}
