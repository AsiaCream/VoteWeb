using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Models
{
    public class Author
    {
        /// <summary>
        /// 作者ID
        /// </summary>
        public long AuthorID { get; set; }
        /// <summary>
        /// 作者姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作者邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 作者简介
        /// </summary>
        public string Introduction { get; set; }
    }
}
