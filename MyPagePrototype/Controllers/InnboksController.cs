using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPagePrototype.DAL;
using MyPagePrototype.Models;

namespace MyPagePrototype.Controllers
{
    public class InnboksController : Controller
    {
        // GET: Innboks

        MinSideContext db = new MinSideContext();

        public ActionResult Index()
        {
            return View(db.Meldinger.ToList());
        }

        // GET: Innboks/Details/5
        public ActionResult Detaljer(int id)
        {
            return View();
        }

        public ActionResult Liste() { 
            
            return View(db.Innboks.ToList()); 
        
        }

    }
}
