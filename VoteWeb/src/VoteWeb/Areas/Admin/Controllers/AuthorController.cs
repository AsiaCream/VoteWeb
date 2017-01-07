using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace VoteWeb.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        // GET: /<controller>/
        private VoteWebDBContext DB;
        public AuthorController(VoteWebDBContext _DBContext)
        {
            DB = _DBContext;
        }

        #region Add
        /// <summary>
        /// 渲染添加视图
        /// </summary>
        /// <returns></returns>
        [Area("Admin")]
        [HttpGet]
        public IActionResult Add() => View();
        /// <summary>
        /// 执行添加方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpPost]
        public IActionResult Add(Author entity)
        {
            JResult _JResult = new JResult();
            _JResult.Code = JResultCode.Failure;
            _JResult.Msg = "操作失败";
            entity.CreateTime=DateTime.Now;
            entity.IsDelete=0;
            DB.Authors.Add(entity);
            int result = DB.SaveChanges();
            //创建作者成功后就创建一个文件夹
            if (result > 0)
            {
                //上传文件的根目录
                var rootFile = ".\\wwwroot\\upload\\";
                _JResult.Code = JResultCode.Success;
                _JResult.Msg = "操作成功";
                Directory.CreateDirectory(rootFile + entity.AuthorID);
            }
            return Json(_JResult);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 根据AuthorID删除作者
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpPost]
        public IActionResult DeleteByAuthorID(long AuthorID)
        {
            JResult _JResult = new JResult();
            _JResult.Code = JResultCode.Failure;
            _JResult.Msg = "操作失败";
            var entity = DB.Authors.SingleOrDefault(x => x.AuthorID == AuthorID);
            if (entity != null)
            {
                DB.Authors.Remove(entity);
                int result = DB.SaveChanges();
                if (result > 0)
                {
                    //保存文件的upload文件夹路径
                    var rootFile = ".\\wwwroot\\upload\\";
                    //删除数据库中保存的作者信息，删除保存作者作品的文件夹
                    _JResult.Code = JResultCode.Success;
                    _JResult.Msg = "操作成功";
                    //删除作者文件夹
                    Directory.Delete(rootFile + AuthorID.ToString() + entity.Name, true);
                    return Json(_JResult);
                }
            }
            return Json(_JResult);
        }
        #endregion

        #region Update

        #endregion

        #region Select
        /// <summary>
        /// 根据AuthorID查询作者
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpGet]
        public IActionResult GetEntityByAuthorID(long AuthorID)
        {
            var entity = DB.Authors.SingleOrDefault(x => x.AuthorID == AuthorID);
            if (entity != null)
            {
                return View(entity);
            }
            return View("404.cshtml");
        }

        /// <summary>
        /// 查询作者列表
        /// </summary>
        /// <returns></returns>
        [Area("Admin")]
        [HttpGet]
        public IActionResult List()
        {
            var list=DB.Authors.OrderByDescending(x=>x.AuthorID).ToList();
            return View(list);
        }
        

        #endregion

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
