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
    public class BrukerController : Controller
    {
        private MinSideContext db = new MinSideContext();

        // GET: Brukers
        public ActionResult Index()
        {
            var brukere = db.Brukere;
                //.Include(b => b.KontaktInfo);
            return View(brukere.ToList());
        }

        // GET: Brukers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bruker bruker = db.Brukere.Find(id);
            if (bruker == null)
            {
                return HttpNotFound();
            }
            return View(bruker);
        }

        // GET: Brukers/Create
        public ActionResult Create()
        {
            ViewBag.BrukerID = new SelectList(db.KontaktInfo, "KontaktInfoID", "Navn");
            return View();
        }

        // POST: Brukers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrukerID,Navn,Passord,Telefonnummer,Epost")] Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                db.Brukere.Add(bruker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrukerID = new SelectList(db.KontaktInfo, "KontaktInfoID", "Navn", bruker.BrukerID);
            return View(bruker);
        }

        // GET: Brukers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bruker bruker = db.Brukere.Find(id);
            if (bruker == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrukerID = new SelectList(db.KontaktInfo, "KontaktInfoID", "Navn", bruker.BrukerID);
            return View(bruker);
        }

        // POST: Brukers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrukerID,Navn,Passord,Telefonnummer,Epost")] Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bruker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrukerID = new SelectList(db.KontaktInfo, "KontaktInfoID", "Navn", bruker.BrukerID);
            return View(bruker);
        }

        // GET: Brukers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bruker bruker = db.Brukere.Find(id);
            if (bruker == null)
            {
                return HttpNotFound();
            }
            return View(bruker);
        }

        // POST: Brukers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bruker bruker = db.Brukere.Find(id);
            db.Brukere.Remove(bruker);
            db.SaveChanges();
            return RedirectToAction("Index");
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
