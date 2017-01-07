using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using VoteWeb.ViewModels;

namespace VoteWeb.Controllers
{
    public class HomeController : Controller
    {
        #region 构造函数
        private VoteWebDBContext DB;
        public HomeController(VoteWebDBContext _db)
        {
            DB = _db;
        } 
        #endregion
        /// <summary>
        /// 前台展示最新的分页数据
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            HomeIndexViewModel _viewmodel=new HomeIndexViewModel();
            _viewmodel.Pictures=DB.Pictures.Where(x => x.IsDelete == 0 && x.IsDisplay == 1)
                .OrderBy(x => x.CreateTime)
                .ToList();
            _viewmodel.Top10Pictures=DB.Pictures.Where(x=>x.IsDelete==0&&x.IsDisplay==1)
            .OrderByDescending(x=>x.Votes)
            .OrderByDescending(x=>x.CreateTime)
            .Take(10)
            .ToList();
            return View(_viewmodel);
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
