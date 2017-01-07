using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Models
{
    public enum JResultCode
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failure,
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("警告")]
        Warning,
        /// <summary>
        /// 询问
        /// </summary>
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
