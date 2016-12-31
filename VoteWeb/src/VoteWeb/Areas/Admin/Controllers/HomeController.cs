using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace VoteWeb.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private VoteWebDBContext DB;
        public HomeController(VoteWebDBContext _DBContext)
        {
            DB = _DBContext;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
