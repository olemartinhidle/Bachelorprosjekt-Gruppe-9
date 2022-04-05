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
    public class KvitteringController : Controller
    {
        private MinSideContext db = new MinSideContext();

        // GET: Kvittering
        public ActionResult Index()
        {
            var kvitteringer = db.Kvitteringer.Include(k => k.Byggesak).Include(k => k.KontaktInfo);
            return View(kvitteringer.ToList());
        }

        // POST: Kvittering/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        public ActionResult genKvittering()
        {


            if (TempData["tempID"] != null || TempData["kontID"] != null)
            {
                int byggID;
                int kontID;
                string byggesakID = TempData["tempID"].ToString();
                string kontaktID = TempData["kontID"].ToString();

                Int32.TryParse(byggesakID, out byggID);
                Int32.TryParse(kontaktID, out kontID);

                
                var bruktID = new List<int>();
                foreach (var item in db.Kvitteringer)
                {
                    bruktID.Add(item.KvitteringID);
                }
                int maxid = bruktID.Max();
                int kvittID = maxid + 1;

                int ByggID;
                int KontID;
                int KvittID;

                ByggID = byggID;
                KontID = kontID;
                KvittID = kvittID;

                Byggesak Byggesak = db.Byggesaker.Find(ByggID);

                Byggesak.KvitteringID = KvittID;
                db.SaveChanges();

   
                KontaktInfo Kont = db.KontaktInfo.Find(KontID);

                Kvittering kvitt = new Kvittering
                {
                    KvitteringID = KvittID,
                    KvitteringsDato = DateTime.Now,
                    Kommentar = "Kommentar til denne saken",
                    Vedlegg = "*Ingen vedlegg lagt til",
                    MatrikkelPath = "/Resources/Matrikkel/matrikkel.png",
                    OrtoPath = "/Resources/OrtoPhoto/orto.png",
                    ByggesakID = Byggesak.ByggesakID,
                    KontaktInfoID = Kont.KontaktInfoID,
                };

                db.Kvitteringer.Add(kvitt);
                db.SaveChanges();



                //return RedirectToAction("/../Kvitterings/Index");
                return RedirectToAction("/../Kvittering/Detaljer/" + KvittID);

            }
            return View();
        }

        // GET: Kvittering/Details/5

        public ActionResult Detaljer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kvittering kvittering = db.Kvitteringer.Find(id);


            //var kvittering = db.Kvitteringer.Include(k => k.Byggesak).Include(k => k.KontaktInfo);


            if (kvittering == null)
            {
                return HttpNotFound();
            }


            int sakID = kvittering.ByggesakID;


            Byggesak byggesak = db.Byggesaker.Find(sakID);

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

            //var liste = db.Kvitteringer.Include(b => b.Byggesak).Include(k => k.KontaktInfo).Where(b => b.ByggesakID == sakID).Where(k => k.KontaktInfoID == id).ToList();

            return View(kvittering);
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
