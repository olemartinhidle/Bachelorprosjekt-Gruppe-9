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
    public class InnboksController : Controller
    {
        private string Err;
        // Ny db instans
        private MinSideContext db = new MinSideContext();

        // Viser til meldinger som er sendt til en gitt bruker
        public ActionResult Index()
        {
            try
            {
                // Bruker ID som er lagret i session
                int brukerID = Convert.ToInt32(Session["brukerID"]);
                
                // Finner meldinger basert på den gitte ID
                var meldinger = db.Meldinger.Where(m => m.BrukerID == brukerID).ToList();


                // Returnerer siden med meldingene til denne brukeren
                return View(meldinger);

            } catch (Exception ex)
            {
                Err = ex.Message;
                return View(Err);
            }
        }

        // Sletter en gitt melding
        public ActionResult Slett(int? mid)
        {
            try
            {
                // Nytt meldingsobjekt basert på id
                Melding melding = db.Meldinger.Find(mid);
                // Fjerner medling
                db.Meldinger.Remove(melding);
                // Lagre endring
                db.SaveChanges();
                return RedirectToAction("Index");
            } catch(Exception ex) 
            { 
                Err = ex.Message; 
                return View(Err); 
            }
        }

        // Frigir ressurser
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            } catch(Exception ex)
            {
                Err = ex.Message;
            }
        }
    }
}
