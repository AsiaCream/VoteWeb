using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace VoteWeb.Areas.Admin.Controllers
{
    [Authorize(Roles ="超级管理员")]
    public class CategoryController : Controller
    {
        private VoteWebDBContext DB { get; set; }
        public CategoryController(VoteWebDBContext _DBContext)
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
        public IActionResult Add(Category entity)
        {
            JResult _JResult = new JResult();
            DB.Categorys.Add(entity);
            ReturnResult(DB.SaveChanges());
            return Json(_JResult);
        }
        #endregion
        #region Delete
        /// <summary>
        /// 通过CategoryID删除分类
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpPost]
        public IActionResult DeleteByCategoryID(long CategoryID)
        {
            JResult _JResult = new JResult();
            var entity = DB.Categorys.SingleOrDefault(x => x.CategoryID == CategoryID);
            if (entity != null)
            {
                DB.Categorys.Remove(entity);
                ReturnResult(DB.SaveChanges());
            }
            else
            {
                _JResult.Code = JResultCode.Error;
                _JResult.Msg = "没有找到要删除的该条记录";
            }
            return Json(_JResult);
        }
        #endregion
        #region Update
        /// <summary>
        /// 渲染更新分类视图
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpGet]
        public IActionResult Update(long CategoryID)
        {
            JResult _JResult = new JResult();
            Category entity = DB.Categorys.SingleOrDefault(x => x.CategoryID == CategoryID);
            if (entity == null)
            {
                _JResult.Code = JResultCode.Warning;
                _JResult.Msg = "未找到指定分类";
                return Json(_JResult);
            }
            return View(entity);
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Update(long CategoryID,Category category)
        {
            JResult _JResult = new JResult();
            var entity = DB.Categorys.SingleOrDefault(x => x.CategoryID == CategoryID);
            if (entity != null)
            {
                entity.Title = category.Title;
                entity.PRI = category.PRI;
                ReturnResult(DB.SaveChanges());
            }
            else
            {
                _JResult.Code = JResultCode.Warning;
                _JResult.Msg = "未找到指定的信息";
            }
            return Json(_JResult);
        }
        #endregion
        #region Delete
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        [Area("Admin")]
        [HttpPost]
        public IActionResult GetEntityByCategoryID(long CategoryID)
        {
            var entity = DB.Categorys.SingleOrDefault(x => x.CategoryID == CategoryID);
            if (entity == null)
            {
                JResult _JResult = new JResult();
                _JResult.Code = JResultCode.Warning;
                _JResult.Msg = "未找到指定的信息";
                return Json(_JResult);
            }
            return View(entity);
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
