using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPagePrototype.DAL;
using MyPagePrototype.Models;

namespace MyPagePrototype.Controllers
{
    [Authorize]
    public class MineByggesakerController : Controller
    {
        private string Err;
        // Lager DB instans
        private MinSideContext db = new MinSideContext();

        // Henter byggesaker til en gitt bruker
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                // Omgjør session til int
                int brukerID = Convert.ToInt32(Session["brukerID"]);

                // Sjekker etter feil i samling
                var kontroll = db.Byggesaker.
                    Where(m => m.BrukerID == brukerID).
                    Where(f => f.KvitteringID == null).
                    ToList();

                // Hvis noen feil er funnet
                if (kontroll.Count > 0)
                {
                    foreach (var item in kontroll)
                    {
                        TempData["ForSlett"] = item.ByggesakID;
                        RedirectToAction("FjernEndring");
                    }
                }

                // Henter byggesaker
                var byggesaker = db.Byggesaker.
                    Where(m => m.BrukerID == brukerID).
                    ToList().
                    OrderByDescending(x => x.ByggesakDato);

                // Gir tilbake siden med sine byggesaker, i en synkende rekkefølge basert på dato
                return View(byggesaker);
            } catch (Exception ex)
            {
                Err = ex.Message;
                return View(Err);
            }
        }

        // Henter listen for å registrere en ny byggesak
        public ActionResult Registrer()
        {
            try
            {
                ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar");
                return View();
            } catch (Exception ex)
            { 
                Err= ex.Message;
                return View(Err);
            }
        }

        // Henter data fra skjema og registerer en ny byggesak
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrer([Bind(Include = "ByggesakID,ByggesakTema,TypeBygg,ByggningsNummer,ByggesakTittel,ByggesakDato,ByggesakStatus,NæringsGruppe,NyttAreal,NyHøyde,KvitteringID")] Byggesak byggesak)
        {
            try
            {
                // Denne if blokken kjører om en sak ikke ble fullført
                // Temp 1 er ikke null hvis en registrering ikke ble fullført korrekt
                if (TempData["tmp1"] != null)
                {
                    if (ModelState.IsValid)
                    {
                        // Den saken som skal oppdateres som ikke ble fullførts id ligger i Temp 2
                        int BID = Convert.ToInt32(TempData["tmp2"]);
                        // Setter denne nye saken til å overskrive den ikke fullførte saken
                        byggesak.ByggesakID = BID;

                        // Finner bruker id fra session
                        int brukerID = Convert.ToInt32(Session["brukerID"]);
                        byggesak.BrukerID = brukerID;

                        // Legger til ny sak i plassen til den ufulførte
                        db.Byggesaker.Add(byggesak);
                        // Lagrer endringene
                        db.SaveChanges();

                        // Setter temp til null
                        TempData["tmp1"] = null;
                        TempData["tmp2"] = null;

                        // Sender bruker til kontaktinfo skjema
                        return RedirectToAction("/../KontaktInfo/Send");
                    }
                }
                else
                {
                    // Denne blokken kjører hvis alt er som det skal være
                    // Hvis modellen er gyldig
                    if (ModelState.IsValid)
                    {
                        // Finner brukerID
                        int brukerID = Convert.ToInt32(Session["brukerID"]);

                        // Setter byggesakens bruker id som den gitte bruker id
                        byggesak.BrukerID = brukerID;

                        // Lager en ny byggesakID basert på høyeste verdi i samlingen og legger til 1
                        byggesak.ByggesakID = db.Byggesaker.OrderByDescending(m => m.ByggesakID).FirstOrDefault().ByggesakID + 1;

                        // Legger til byggesaken i db instans
                        db.Byggesaker.Add(byggesak);
                        // Lagrer endringene
                        db.SaveChanges();

                        // Sender bruker til skjema for å legge til ny kontaktinfo i saken
                        return RedirectToAction("/../KontaktInfo/Send");

                    }
                }

                ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar", byggesak.ByggesakID);
                // Ellers returneres siden med data
                return View(byggesak);
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return View(Err);
            }
        }

        // Fjerner endring til byggesakene
        // Brukes hvis innsending ikke fullføres
        
        public ActionResult FjernEndring()
        {
            try
            {
                // Finner byggesak id
                int bid = Convert.ToInt32(TempData["ForSlett"]);
                // Finner byggesaken med den gitte ID
                var sak = db.Byggesaker.Find(bid);

                // Setter temp data for bruk ved ny byggesak
                TempData["tmp1"] = "IF";
                // Finner id fra den ufullførte saken
                TempData["tmp2"] = sak.ByggesakID;

                // Fjerner den gitte byggesak
                db.Byggesaker.Remove(sak);
                // Lagrer endringene
                db.SaveChanges();

                // Sender bruker til byggesak listen
                return RedirectToAction("Index");
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
            }
            catch (Exception ex)
            {
                Err = ex.Message;
            }
        }
    }

}

