using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace VoteWeb.Areas.Admin.Controllers
{
    public class ConfigController : Controller
    {
        private VoteWebDBContext DB;
        public ConfigController(VoteWebDBContext _DBContext)
        {
            DB = _DBContext;
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult SEO()
        {
            return View();
        }
    }
}
