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
        // Ny db instans
        private MinSideContext db = new MinSideContext();

        // Viser til meldinger som er sendt til en gitt bruker
        public ActionResult Index()
        {
            // Bruker ID som er lagret i session
            string id = Session["brukerID"].ToString();
            // Omgjør ID til en int
            Int32.TryParse(id, out int brukerID);
            // Finner meldinger basert på den gitte ID
            var meldinger = db.Meldinger.Where(m => m.BrukerID == brukerID);
            // Returnerer siden med meldingene til denne brukeren
            return View(meldinger.ToList());
        }

        // Sletter en gitt      
        public ActionResult Slett(int? mid)
        {
            // Nytt meldingsobjekt basert på id
            Melding melding = db.Meldinger.Find(mid);
            // Fjerner medling
            db.Meldinger.Remove(melding);
            // Lagre endring
            db.SaveChanges();
            return RedirectToAction("Index");
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
