using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using VoteWeb.ViewModels;

namespace VoteWeb.Controllers
{
    public class SearchController : Controller
    {
        #region 构造函数
        private VoteWebDBContext DB;
        public SearchController(VoteWebDBContext _db)
        {
            DB = _db;
        } 
        #endregion
        // GET: /<controller>/
        public IActionResult List(string keyword)
        {
            SearchListViewModel _viewmodel = new SearchListViewModel();
            _viewmodel.keyword = keyword;
            _viewmodel.authors = DB.Authors.Where(x => x.Name.Contains(keyword))
                .OrderByDescending(x => x.CreateTime)
                .ToList();
            _viewmodel.categorys = DB.Categorys.Where(x => x.Title.Contains(keyword))
                .OrderByDescending(x => x.CreateTime)
                .ToList();
            _viewmodel.pictures = DB.Pictures.Where(x => x.Title.Contains(keyword))
                .OrderByDescending(x => x.Title.Contains(keyword))
                .ToList();
            return View(_viewmodel);
        }
    }
}
