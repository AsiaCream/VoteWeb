using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Models
{
    public class Category
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public long CategoryID { get; set; }
        /// <summary>
        /// 分类标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int PRI { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 是否已经结束
        /// </summary>
        public int IsEnd { get; set; }
        /// <summary>
        /// 是否已经删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}
