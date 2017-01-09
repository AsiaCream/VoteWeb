using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel;

namespace VoteWeb.Models
{
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        [Description("超级管理员")]
        SuperAdmin=1,
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin=2,
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        User=3
    }
    public class User: IdentityUser<long>
    {
        [Key]
        public long UserID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
