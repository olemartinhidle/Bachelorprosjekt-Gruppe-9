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
        // Errror felt
        private string Err;
        // Lager en db instans
        private MinSideContext db = new MinSideContext();
       

        // Åpner en hjem side, som om en bruker er logget inn
        public ActionResult Index()
        {
            try
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
            } catch (Exception ex) 
            { 
                Err = ex.Message;
                return View(Err); 
            }
        }

        public ActionResult LoggInn()
        {
            try
            {
                    /*
                    Her kunne logg inn funksjonalitet vært
                    */
                    // Logg inn skjer via ID-Porten så bruker sendes til Hjem siden
                    return RedirectToAction("Index");

            } catch (Exception ex)
            {
                    Err = ex.Message;
                    return RedirectToAction("../Shared/Error", Err);
            }
        }

        public ActionResult LoggUt()
        {
            try
            {
                    // Fjerner all temp data
                    TempData.Clear();
                    // Fjerner alt fra Session
                    Session.RemoveAll();
                    // Sender bruker til logget ut siden
                    return View("LoggUt");

            }
            catch (Exception ex)
            {
                    Err = ex.Message;
                    return RedirectToAction("../Shared/Error", Err);
            }
        }

        // Tom side som sender bruker tilbake til hjem siden, ettersom det er mange funksjoner vi ikke tar stilling til
        // På kommunens hjemmeside i denne prototypen
        public ActionResult Placeholder()
        {
            try
            {
                ViewBag.Message = "Tom side, ettersom den ikke behøves i denne prototypen.";

                return View();
            } catch (Exception ex)
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
            } catch (Exception ex)
            {
                Err =ex.Message;
            }
        }

    }
}