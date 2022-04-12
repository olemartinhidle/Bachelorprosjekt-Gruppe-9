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
    public class ProfilController : Controller
    {
        // Lager db instans
        private MinSideContext db = new MinSideContext();

        // Henter profil siden til en innlogget bruker
        public ActionResult Index()
        {
            // Finner brukerID
            int brukerID = Convert.ToInt32(Session["brukerID"]);

            // Finner brukerobjekt
            var bruker = db.Brukere.Find(brukerID);
            // Returnerer siden med brukerobjekt
            return View(bruker);
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
