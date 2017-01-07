using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using VoteWeb.ViewModels;
using VoteWeb.ViewModels.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;


namespace VoteWeb.Areas.Admin.Controllers
{
    public class PictureController : Controller
    {
        private IHostingEnvironment Env;
        private VoteWebDBContext DB;
        public PictureController(IHostingEnvironment _env,VoteWebDBContext _db)
        {
            Env = _env;
            DB = _db;
        }
        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Add(Picture entity,IList<IFormFile> files)
        //{
        //    #region 添加参数
        //    entity.CreateTime = DateTime.Now;
        //    entity.IsDelete = 0;
        //    entity.IsDisplay = 1;
        //    #endregion
        //    JResult _JResult = new JResult();
        //    long size = 0;
        //    foreach(var file in files)
        //    {
        //        var filename = ContentDispositionHeaderValue
        //            .Parse(file.ContentDisposition)
        //            .FileName
        //            .Trim('"');
        //        filename = Env.WebRootPath + @"\{fileName}";
        //        size += file.Length;
        //        using(FileStream fs = System.IO.File.Create(filename))
        //        {
        //            file.CopyTo(fs);
        //            fs.Flush();
        //        }
        //    }
        //    _JResult.Code = JResultCode.Success;
        //    _JResult.Msg = "添加成功";
        //    return Json(_JResult);
        //}
        [Area("Admin")]
        [HttpPost]
        public IActionResult Add(Picture entity,IFormFile file)
        {
            #region 添加参数
            entity.CreateTime = DateTime.Now;
            entity.IsDelete = 0;
            entity.IsDisplay = 1;
            #endregion
            JResult _JResult = new JResult();
            var authorFile = "\\upload\\" + entity.AuthorID;
            var fileName = Path.Combine(
                entity.Title
                + DateTime.Now.ToString("MMddHHmmss")
                + ".jpg");
            using (var stream = new FileStream(Path.Combine(Env.WebRootPath+authorFile, fileName), FileMode.CreateNew))
            {
                file.CopyTo(stream);
                entity.PictureURL = fileName;
            }
            DB.Pictures.Add(entity);
            ReturnResult(DB.SaveChanges());
            return Json(_JResult);
        }

        /// <summary>
        /// 根据AuthorID查询作品信息  GetListByAuthorID
        /// </summary>
        /// <param name="AuthorID">作者信息</param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpGet]
        public IActionResult List(long AuthorID)
        {
            PictureListViewModel _viewmodel=new PictureListViewModel();
            _viewmodel.Pictures=DB.Pictures.Where(x=>x.AuthorID==AuthorID)
            .OrderByDescending(x=>x.Votes)
            .OrderByDescending(x=>x.CreateTime)
            .ThenByDescending(x=>x.IsDisplay)
            .ThenBy(x=>x.IsDelete)
            .ToList();
            _viewmodel.author=DB.Authors.SingleOrDefault(x=>x.AuthorID==AuthorID);
            return View("/Areas/Admin/Views/Picture/List.cshtml",_viewmodel);
        }

        /// <summary>
        /// 根据CategoryID查询作品信息  GetListByCategoryID
        /// </summary>
        /// <param name="CategoryID">分类信息</param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpGet]
        public IActionResult CList(long CategoryID)
        {
            PictureCListViewModel _viewmodel=new PictureCListViewModel();
            _viewmodel.Pictures=DB.Pictures.Where(x=>x.CategoryID==CategoryID)
            .OrderByDescending(x=>x.Votes)
            .OrderByDescending(x=>x.CreateTime)
            .ThenByDescending(x=>x.IsDisplay)
            .ThenBy(x=>x.IsDelete)
            .ToList();
            _viewmodel.category=DB.Categorys.SingleOrDefault(x=>x.CategoryID==CategoryID);
            return View("/Areas/Admin/Views/Picture/CList.cshtml",_viewmodel);
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult Detail(long PictureID)
        {
            var entity=DB.Pictures.SingleOrDefault(x=>x.PictureID==PictureID);
            return View("/Areas/Admin/Views/Picture/Detail.cshtml",entity);
        }

        private JResult ReturnResult(int result)
        {
            JResult _JResult = new JResult();
            switch (result)
            {
                case 1:
                    _JResult.Code = JResultCode.Success;
                    _JResult.Msg = "操作成功";
                    break;
                case 0:
                    _JResult.Code = JResultCode.Failure;
                    _JResult.Msg = "操作失败";
                    break;
            }
            return _JResult;
        }
    }
}
