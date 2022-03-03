using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers
{
    public class KvitteringController : Controller
    {
        // GET: Kvittering
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kvittering/Details/5
        public ActionResult Detaljer(int id)
        {
            return View();
        }

    }
}
