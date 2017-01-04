using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoteWeb.Models;
using VoteWeb.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace VoteWeb.Areas.Admin.Controllers
{
    public class PictrueController : Controller
    {
        private IHostingEnvironment Env;
        private VoteWebDBContext DB;
        public PictrueController(IHostingEnvironment _env,VoteWebDBContext _db)
        {
            Env = _env;
            DB = _db;
        }
        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Add(Pictrue entity,IList<IFormFile> files)
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
        [HttpPost]
        public IActionResult Add(Pictrue entity)
        {
            #region 添加参数
            entity.CreateTime = DateTime.Now;
            entity.IsDelete = 0;
            entity.IsDisplay = 1; 
            #endregion
            JResult _JResult = new JResult();
            Author author = DB.Authors.SingleOrDefault(x => x.AuthorID == entity.AuthorID);
            var fileName = Path.Combine("upload", 
                DateTime.Now.ToString("MMddHHmmss") 
                + entity.AuthorID 
                + entity.Title + ".jpg");
            using(var stream=new FileStream(Path.Combine(Env.WebRootPath, fileName), FileMode.CreateNew))
            {
                //entity.Img.CopyTo(stream);
            }
            DB.Pictrues.Add(entity);
            ReturnResult(DB.SaveChanges());
            return Json(_JResult);
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
