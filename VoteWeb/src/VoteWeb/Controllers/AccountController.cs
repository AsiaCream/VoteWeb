using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VoteWeb.Controllers
{
    public class AccountController : Controller
    {
        #region 构造函数
        private SignInManager<User> SignInManager;
        private UserManager<User> UserManager;
        public AccountController(SignInManager<User> _SignInManager, UserManager<User> _UserManager)
        {
            SignInManager = _SignInManager;
            UserManager = _UserManager;
        } 
        #endregion

        // GET: /<controller>/
        /// <summary>
        /// 渲染登陆视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 执行登陆方法
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        {
            var result = await SignInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return Redirect("/Admin/Home/Index");
            }
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// 登出方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
