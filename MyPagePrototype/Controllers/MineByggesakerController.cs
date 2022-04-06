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

            Int32.TryParse(id, out int brukerID);

            var byggesaker = db.Byggesaker.Where(m => m.BrukerID == brukerID);

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

                
                Int32.TryParse(id, out int brukerID);

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

                return RedirectToAction("/../KontaktInfo/Send");
            }

            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar", byggesak.ByggesakID);
            return View(byggesak);
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

        public ActionResult FjernEndring()
        {
            int bid =Int32.Parse(TempData["bid"].ToString());

            var sak = db.Byggesaker.Find(bid);
            db.Byggesaker.Remove(sak);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}

