using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VoteWeb.Models;

namespace VoteWeb.Controllers
{
    public class BaseController : Controller
    {
        internal VoteWebDBContext DB;
        public BaseController(VoteWebDBContext _db)
        {
            DB = _db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            //context.HttpContext.Connection.LocalIpAddress.MapToIPv4();
            ViewBag.Categorys = DB.Categorys.OrderByDescending(x => x.CreateTime)
                .Take(3).ToList();
        }
    }
}
