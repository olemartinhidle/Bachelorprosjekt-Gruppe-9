using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Placeholder()
        {
            ViewBag.Message = "Tom side, ettersom den ikke behøves i denne prototypen.";

            return View();
        }

    }
}