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
        // Lager en db instans
        private MinSideContext db = new MinSideContext();
        // Åpner en hjem side, som om en bruker er logget inn
        public ActionResult Index()
        {
            // Setter av en bruker id, dette vil da være fra MinID innloggingen
            // Her er bare satt 1 ettersom vi ikke bruker MinID i denne prototypen
            int brukerID = 1;

            // Finner info om denne brukeren basert på id fra MinID
            var bruker = db.Brukere.Find(brukerID);

            // Setter av session vairiabler basert på den innloggede brukeren
            Session["BrukerID"] = bruker.BrukerID;
            Session["BrukerNavn"] = bruker.Navn;
            Session["BrukerEpost"] = bruker.Epost;
            Session["BrukerTlf"] = bruker.Telefonnummer;

            return View(bruker);
        }

        // Tom side som sender bruker tilbake til hjem siden, ettersom det er mange funksjoner vi ikke tar stilling til
        // På kommunens hjemmeside i denne prototypen
        public ActionResult Placeholder()
        {
            ViewBag.Message = "Tom side, ettersom den ikke behøves i denne prototypen.";

            return View();
        }

        // Frigir ressurser
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}