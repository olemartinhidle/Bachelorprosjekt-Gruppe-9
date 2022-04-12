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
    [Authorize]
    public class ProfilController : Controller
    {
        private string Err;
        // Lager db instans
        private MinSideContext db = new MinSideContext();

        // Henter profil siden til en innlogget bruker
        public ActionResult Index()
        {
            try
            {
                // Finner brukerID
                int brukerID = Convert.ToInt32(Session["brukerID"]);

                // Finner brukerobjekt
                var bruker = db.Brukere.Find(brukerID);
                // Returnerer siden med brukerobjekt
                return View(bruker);
            }
            catch (Exception ex) 
            { 
                Err = ex.Message; 
                return View(Err);
            }
        }


        // Frigir ressurser
        protected override void Dispose(bool disposing)
        {
            try {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }catch (Exception ex)
            {
                Err = ex.Message;
            }
            }

    }
}
