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
    public class KontaktInfoController : Controller
    {
        private MinSideContext db = new MinSideContext();

        // Henter listen for å lagre ny kontaktinfo til denne saken
        // Fyller inn med nyligste inførte info
        public ActionResult Send()
        {
            // Finner den kontaktifoen med den høyeste id en, nyliste*
            KontaktInfo info = db.KontaktInfo.OrderByDescending(k => k.KontaktInfoID).FirstOrDefault();

            // Fyller dette inn i listen på siden
            return View(info);
        }

        // POST: KontaktInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // Sender sak, og lager ny kontakt info som brukes i kvittering
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send([Bind(Include = "Navn,Telefonnummer,Epost,MailØnsket,Samtykke")] KontaktInfo kontaktInfo)
        {
            if (ModelState.IsValid)
            {
                // Henter bruker id fra session
                // Omgjør string til int
                int brukerID = Convert.ToInt32(Session["brukerID"]);
                
                // Setter brukerID til den gitte int i kontaktinfoen
                kontaktInfo.BrukerID = brukerID;
                // Legger til den nye kontaktinfoen til db instansen
                db.KontaktInfo.Add(kontaktInfo);
                // Lagrer endringene
                db.SaveChanges();

                return RedirectToAction("/../Kvittering/GenKvittering");

            }
            // Ellers returnerer den til siden
            return View(kontaktInfo);
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
