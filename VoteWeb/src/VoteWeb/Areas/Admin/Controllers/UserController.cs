using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using VoteWeb.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace VoteWeb.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private VoteWebDBContext DB;
        private UserManager<User> UserManager;
        public UserController(VoteWebDBContext _db, UserManager<User> _userManager)
        {
            DB = _db;
            UserManager = _userManager;
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public IActionResult Add(string username,string password,int usertype)
        {
            JResult _JResult = new JResult();
            User user = new User
            {
                UserName = username,
                CreateTime = DateTime.Now
            };
            UserManager.CreateAsync(user, password);
            UserManager.AddToRoleAsync(user, AddToRole(usertype));
            _JResult.Code = JResultCode.Success;
            _JResult.Msg = "操作成功";
            return Json(_JResult);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public IActionResult ModifyPassWord(string password,string newpwd)
        {
            JResult _JResult = new JResult();
            return Json(_JResult);
        }

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="usertype"></param>
        /// <returns></returns>
        private string AddToRole(int usertype)
        {
            string role = string.Empty;
            switch (usertype)
            {
                case 1:
                    role = "超级管理员";
                    break;
                case 2:
                    role = "管理员";
                    break;
                case 3:
                    role = "普通用户";
                    break;
            }
            return role;
        }

        /// <summary>
        /// 获取当前操作用户
        /// </summary>
        /// <returns></returns>
        private Task<User> GetCurrentUserAsync()
        {
            return UserManager.GetUserAsync(HttpContext.User);
        }
    }
}
