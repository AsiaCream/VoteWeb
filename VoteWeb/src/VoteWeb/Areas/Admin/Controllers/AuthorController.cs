using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;

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
        [HttpGet]
        public IActionResult Add() => View();
        /// <summary>
        /// 执行添加方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Author entity)
        {
            JResult _JResult = new JResult();
            DB.Authors.Add(entity);
            ReturnResult(DB.SaveChanges());
            return Json(_JResult);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 根据AuthorID删除作者
        /// </summary>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteByAuthorID(long AuthorID)
        {
            JResult _JResult = new JResult();
            var entity = DB.Authors.SingleOrDefault(x => x.AuthorID == AuthorID);
            if (entity != null)
            {
                DB.Authors.Remove(entity);
                return Json(ReturnResult(DB.SaveChanges()));
            }
            _JResult.Code = JResultCode.Warning;
            _JResult.Msg = "未找符合条件的信息";
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
        [HttpGet]
        public IActionResult GetEntityByAuthorID(long AuthorID)
        {
            var entity = DB.Authors.SingleOrDefault(x => x.AuthorID == AuthorID);
            if (entity != null)
            {
                return View();
            }
            return View("404.cshtml");
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
