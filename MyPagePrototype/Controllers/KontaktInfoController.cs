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

        // GET: KontaktInfo
        public ActionResult Index()
        {
            return View(db.KontaktInfo.ToList());
        }

        // GET: KontaktInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktInfo kontaktInfo = db.KontaktInfo.Find(id);
            if (kontaktInfo == null)
            {
                return HttpNotFound();
            }
            return View(kontaktInfo);
        }

        // GET: KontaktInfo/Create
        public ActionResult Send()
        {
            return View();
        }

        // POST: KontaktInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send([Bind(Include = "Navn,Telefonnummer,Epost,MailØnsket,Samtykke")] KontaktInfo kontaktInfo)
        {
            if (ModelState.IsValid)
            {
               
                //var byggID = TempData["tempID"];
                db.KontaktInfo.Add(kontaktInfo);
                db.SaveChanges();

                //return RedirectToAction("/../KontaktInfo/Index");

                var bruktID = new List<int>();

                foreach (var item in db.KontaktInfo)
                {
                    bruktID.Add(item.KontaktInfoID);
                }

                int maxid = bruktID.Max();

                kontaktInfo.KontaktInfoID = maxid;
            
                TempData["kontID"] = kontaktInfo.KontaktInfoID;


                //return View(kontaktInfo);
                return RedirectToAction("/../Kvittering/genKvittering");
            }

            return View(kontaktInfo);
        }

        // GET: KontaktInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktInfo kontaktInfo = db.KontaktInfo.Find(id);
            if (kontaktInfo == null)
            {
                return HttpNotFound();
            }
            return View(kontaktInfo);
        }

        // POST: KontaktInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Navn,Telefonnummer,Epost,MailØnsket,Samtykke")] KontaktInfo kontaktInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontaktInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontaktInfo);
        }

        // GET: KontaktInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KontaktInfo kontaktInfo = db.KontaktInfo.Find(id);
            if (kontaktInfo == null)
            {
                return HttpNotFound();
            }
            return View(kontaktInfo);
        }

        // POST: KontaktInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KontaktInfo kontaktInfo = db.KontaktInfo.Find(id);
            db.KontaktInfo.Remove(kontaktInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
