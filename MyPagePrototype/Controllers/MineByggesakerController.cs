using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPagePrototype.DAL;
using MyPagePrototype.Models;

namespace MyPagePrototype.Controllers
{
    public class MineByggesakerController : Controller
    {

        private MinSideContext db = new MinSideContext();

        // GET: Byggesaker
        public ActionResult Index()
        {

            string id = Session["brukerID"].ToString();

            int brukerID;
            Int32.TryParse(id, out brukerID);

            var byggesaker = db.Byggesaker.Where(m => m.BrukerID == brukerID);


            //var kvitteringer = db.Byggesaker.Include(k => k.Byggesak);


            return View(byggesaker.ToList().OrderByDescending(x => x.ByggesakDato));


        }

        // GET: Byggesaker/Details/5
        public ActionResult Detaljer(int id)
        {
            return View();
        }

        public ActionResult Oppsummering()
        {
            if ((TempData["shortMessage"] != null))
            {
                ViewBag.Status = TempData["shortMessage"].ToString();
            }
            return View();
        }

        public ActionResult OppIB()
        {
            TempData["shortMessage"] = "ib";
            return RedirectToAction("Oppsummering");
        }

        public ActionResult OppUB()
        {
            TempData["shortMessage"] = "ub";
            return RedirectToAction("Oppsummering");
        }

        public ActionResult OppFB()
        {
            TempData["shortMessage"] = "fb";
            return RedirectToAction("Oppsummering");
        }


        // GET: Byggesaker/Create
        public ActionResult Registrer()
        {
            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar");
            return View();
        }

        // POST: Byggesaker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrer([Bind(Include = "ByggesakID,ByggesakTema,TypeBygg,ByggningsNummer,ByggesakTittel,ByggesakDato,ByggesakStatus,NæringsGruppe,NyttAreal,NyHøyde,KvitteringID")] Byggesak byggesak)
        {
            if (ModelState.IsValid)
            {

                string id = Session["brukerID"].ToString();

                int brukerID;
                Int32.TryParse(id, out brukerID);

                byggesak.BrukerID = brukerID;


                db.Byggesaker.Add(byggesak);
                db.SaveChanges();


                var bruktID = new List<int>();

                foreach (var item in db.Byggesaker)
                {
                    bruktID.Add(item.ByggesakID);
                }

                int maxid = bruktID.Max();

                byggesak.ByggesakID = maxid;

                TempData["tempID"] = byggesak.ByggesakID;


                //return RedirectToAction("/../Byggesaks/Index");

                return RedirectToAction("/../KontaktInfo/Send");
            }

            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar", byggesak.ByggesakID);
            return View(byggesak);
        }

        // GET: Byggesaker/Edit/5
        public ActionResult OppdaterSak(int id)
        {
            return View();
        }

        // POST: Byggesaker/Edit/5
        [HttpPost]
        public ActionResult OppdaterSak(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Byggesaker/Delete/5
        public ActionResult SlettSak(int id)
        {
            return View();
        }

        // POST: Byggesaker/Delete/5
        [HttpPost]
        public ActionResult SlettSak(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Byggesaker/Create
        public ActionResult KontaktSkjema()
        {
            return View();
        }

        // POST: Byggesaker/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KontaktSkjema([Bind(Include = "ID,Navn,Telefonnummer,Epost,MailØnsket,Samtykke")] KontaktInfo kontaktInfo)
        {
            if (ModelState.IsValid)
            {
                db.KontaktInfo.Add(kontaktInfo);
                db.SaveChanges();
                return RedirectToAction("OppIB");
            }

            return View(kontaktInfo);
        }
    }

}

