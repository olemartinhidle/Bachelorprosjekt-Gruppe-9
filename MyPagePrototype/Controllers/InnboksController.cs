using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers
{
    public class InnboksController : Controller
    {
        // GET: Innboks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Innboks/Details/5
        public ActionResult Detaljer(int id)
        {
            return View();
        }


    }
}
