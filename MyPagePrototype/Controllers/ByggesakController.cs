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
    public class ByggesakController : Controller
    {
        private MinSideContext db = new MinSideContext();

        // GET: Byggesak
        public ActionResult Index()
        {
            var byggesaker = db.Byggesaker.Include(b => b.Kvittering);
            return View(byggesaker.ToList());
        }

        // GET: Byggesak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byggesak byggesak = db.Byggesaker.Find(id);
            if (byggesak == null)
            {
                return HttpNotFound();
            }
            return View(byggesak);
        }

        // GET: Byggesak/Create
        public ActionResult Create()
        {
            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar");
            return View();
        }

        // POST: Byggesak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ByggesakID,ByggesakTema,TypeBygg,BygningsNummer,ByggesakTittel,ByggesakDato,ByggesakStatus,NæringsGruppe,NyttAreal,NyHøyde")] Byggesak byggesak)
        {
            if (ModelState.IsValid)
            {
                db.Byggesaker.Add(byggesak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar", byggesak.ByggesakID);
            return View(byggesak);
        }

        // GET: Byggesak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byggesak byggesak = db.Byggesaker.Find(id);
            if (byggesak == null)
            {
                return HttpNotFound();
            }
            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar", byggesak.ByggesakID);
            return View(byggesak);
        }

        // POST: Byggesak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ByggesakID,ByggesakTema,TypeBygg,BygningsNummer,ByggesakTittel,ByggesakDato,ByggesakStatus,NæringsGruppe,NyttAreal,NyHøyde")] Byggesak byggesak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(byggesak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ByggesakID = new SelectList(db.Kvitteringer, "KvitteringID", "Kommentar", byggesak.ByggesakID);
            return View(byggesak);
        }

        // GET: Byggesak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Byggesak byggesak = db.Byggesaker.Find(id);
            if (byggesak == null)
            {
                return HttpNotFound();
            }
            return View(byggesak);
        }

        // POST: Byggesak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Byggesak byggesak = db.Byggesaker.Find(id);
            db.Byggesaker.Remove(byggesak);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HentKvittering(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kvittering kvittering = db.Kvitteringer.Find(id);
            if (kvittering == null)
            {
                return HttpNotFound();
            }
            return View(kvittering);
        }


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
