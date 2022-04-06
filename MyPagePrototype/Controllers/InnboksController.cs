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
    public class InnboksController : Controller
    {
        private MinSideContext db = new MinSideContext();

        // GET: Meldings
        public ActionResult Index()
        {
            string id = Session["brukerID"].ToString();

            int brukerID;
            Int32.TryParse(id, out brukerID);

            var meldinger = db.Meldinger.Where(m => m.BrukerID == brukerID);
            return View(meldinger.ToList());
        }

        // GET: Meldings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melding melding = db.Meldinger.Find(id);
            if (melding == null)
            {
                return HttpNotFound();
            }
            return View(melding);
        }

        // GET: Meldings/Create
        public ActionResult Create()
        {
            ViewBag.BrukerID = new SelectList(db.Brukere, "BrukerID", "Navn");
            return View();
        }

        // POST: Meldings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeldingID,MeldingDato,MeldingTittel,MeldingAvsender,MeldingFilPath,BrukerID")] Melding melding)
        {
            if (ModelState.IsValid)
            {
                db.Meldinger.Add(melding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrukerID = new SelectList(db.Brukere, "BrukerID", "Navn", melding.BrukerID);
            return View(melding);
        }

        // GET: Meldings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melding melding = db.Meldinger.Find(id);
            if (melding == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrukerID = new SelectList(db.Brukere, "BrukerID", "Navn", melding.BrukerID);
            return View(melding);
        }

        // POST: Meldings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeldingID,MeldingDato,MeldingTittel,MeldingAvsender,MeldingFilPath,BrukerID")] Melding melding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(melding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrukerID = new SelectList(db.Brukere, "BrukerID", "Navn", melding.BrukerID);
            return View(melding);
        }

        // GET: Meldings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Melding melding = db.Meldinger.Find(id);
            if (melding == null)
            {
                return HttpNotFound();
            }
            return View(melding);
        }

        // POST: Meldings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Melding melding = db.Meldinger.Find(id);
            db.Meldinger.Remove(melding);
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
