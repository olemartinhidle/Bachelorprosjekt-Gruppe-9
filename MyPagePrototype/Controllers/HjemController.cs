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
    public class HjemController : Controller
    {
        private MinSideContext db = new MinSideContext();

        public ActionResult Index()
        {

            int brukerID = 1;

            var bruker = db.Brukere.Find(brukerID);

            Session["BrukerID"] = bruker.BrukerID;
            Session["BrukerNavn"] = bruker.Navn;
            Session["BrukerEpost"] = bruker.Epost;
            Session["BrukerTlf"] = bruker.Telefonnummer;

            return View(bruker);
        }

        public ActionResult Placeholder()
        {
            ViewBag.Message = "Tom side, ettersom den ikke behøves i denne prototypen.";

            return View();
        }

    }
}