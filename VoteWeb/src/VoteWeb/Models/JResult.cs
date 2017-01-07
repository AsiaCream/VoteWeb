using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Models
{
    public enum JResultCode
    {
        [Description("失败")]
        Failure,
        [Description("成功")]
        Success,
        [Description("错误")]
        Error,
        [Description("警告")]
        Warning,
        [Description("询问")]
        Confirm
    }
    public class JResult
    {
        /// <summary>
        /// 返回的内容
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回代码
        /// </summary>
        public JResultCode Code { get; set; }
        /// <summary>
        /// 返回对象
        /// </summary>
        public object Result { get; set; }
    }
}
