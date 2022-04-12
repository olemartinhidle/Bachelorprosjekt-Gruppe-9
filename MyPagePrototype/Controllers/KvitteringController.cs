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
    public class KvitteringController : Controller
    {
        private string Err;
        // Setter db instans
        private MinSideContext db = new MinSideContext();
        
        // POST: Kvittering/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // Genererer en kvittering basert på kontaktskjema og byggesak
        public ActionResult GenKvittering()
        {
            try
            {
                // Finner gitt bruker fra session
                int brukerID = Convert.ToInt32(Session["brukerID"]);

                // Lager den neste IDen basert på den høyeste Iden allerede lagt til, ut frra alle kvitteringer
                int KvittID = db.Kvitteringer.OrderByDescending(m => m.KvitteringID).FirstOrDefault().KvitteringID + 1;
                // Finner de ulike IDene som brukes til å generere kvitteringen, basert på innlogget bruker
                int KontID = db.KontaktInfo.Where(k => k.BrukerID == brukerID).OrderByDescending(m => m.KontaktInfoID).FirstOrDefault().KontaktInfoID;
                int ByggID = db.Byggesaker.Where(k => k.BrukerID == brukerID).OrderByDescending(m => m.ByggesakID).FirstOrDefault().ByggesakID;

                // Lager en ny kvittering basert på innsamlet data
                // Noen av feltene her skal komme fra AI og derfor bare 
                // Hardkodes i denne prototypen
                Kvittering kvitt = new Kvittering
                {
                    KvitteringID = KvittID,
                    KvitteringsDato = DateTime.Now,
                    Kommentar = "Kommentar til denne saken",
                    Vedlegg = "*Ingen vedlegg lagt til",
                    MatrikkelPath = "/Resources/Matrikkel/matrikkel.png",
                    OrtoPath = "/Resources/OrtoPhoto/orto.png",
                    ByggesakID = ByggID,
                    KontaktInfoID = KontID,
                };

                // Legger til den nye kvitteringen
                db.Kvitteringer.Add(kvitt);
                // Lagrer endringen
                db.SaveChanges();

                // Finner et byggesak objekt basert på id
                Byggesak Byggesak = db.Byggesaker.OrderByDescending(m => m.ByggesakID).FirstOrDefault();
                // Oppdaterer byggesak med den nye IDen
                Byggesak.KvitteringID = KvittID;
                // Lagrer endringen
                db.SaveChanges();

                // Sender bruker til oppsummering siden
                return RedirectToAction("/../Kvittering/Detaljer/" + KvittID);
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return RedirectToAction("/../MineByggesaker/Index", Err);
            }

        }

        // Henter siden som viser kvitteringen og dens genererte innhold
        public ActionResult Detaljer(int? id)
        {
            try
            {
                // Hvis id er tom
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                // Finner et kvitteringsobjekt basert på ID
                Kvittering kvittering = db.Kvitteringer.Find(id);
                // HVis kvittering er tom
                if (kvittering == null)
                {
                    return HttpNotFound();
                }
                // Finner byggesak id
                int sakID = kvittering.ByggesakID;
                // Lager et byggesak objekt
                Byggesak byggesak = db.Byggesaker.Find(sakID);
                // Sjekker statusen på byggesaken
                if (byggesak.ByggesakStatus == "Ubehandlet")
                {
                    ViewBag.Status = "ib";
                }
                if (byggesak.ByggesakStatus == "Under behandling")
                {
                    ViewBag.Status = "ub";
                }
                if (byggesak.ByggesakStatus == "Ferdig behandlet")
                {
                    ViewBag.Status = "fb";
                }
                // Returnerer siden med en gitt kvittering
                return View(kvittering);
            } catch (Exception ex)
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
            } catch (Exception ex)
            {
                Err = ex.Message;
            }
            }

    }
}
