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
    public class MeldingController : Controller
    {
        private MinSideContext db = new MinSideContext();

        // GET: Melding
        public ActionResult Index()
        {
            return View(db.Meldinger.ToList());
        }

        // GET: Melding/Details/5
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

        // GET: Melding/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Melding/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeldingID,MeldingDato,MeldingTittel,MeldingAvsender,MeldingFilPath")] Melding melding)
        {
            if (ModelState.IsValid)
            {
                db.Meldinger.Add(melding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(melding);
        }

        // GET: Melding/Edit/5
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
            return View(melding);
        }

        // POST: Melding/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeldingID,MeldingDato,MeldingTittel,MeldingAvsender,MeldingFilPath")] Melding melding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(melding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(melding);
        }

        // GET: Melding/Delete/5
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

        // POST: Melding/Delete/5
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

