using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using VoteWeb.ViewModels;

namespace VoteWeb.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(VoteWebDBContext _db) : base(_db)
        {
        }

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

        /// <summary>
        /// 图片详情页面
        /// </summary>
        /// <param name="PictureID"></param>
        /// <returns></returns>
        public IActionResult Detail(int PictureID)
        {
            HomeDetailViewModel _viewmodel = new HomeDetailViewModel();
            Picture entity = DB.Pictures
                .SingleOrDefault(x => x.PictureID == PictureID);
            _viewmodel.picture = entity;
            _viewmodel.NewPictures = DB.Pictures
                .Where(x => x.IsDisplay == 1 && x.IsDelete == 0)
                .OrderByDescending(x => x.CreateTime)
                .ToList();
            _viewmodel.SimilarPictures = DB.Pictures
                .Where(x => x.IsDisplay == 1 && x.IsDelete == 0 && x.CategoryID == entity.CategoryID)
                .OrderByDescending(x => x.CreateTime)
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
        public IActionResult Save()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
