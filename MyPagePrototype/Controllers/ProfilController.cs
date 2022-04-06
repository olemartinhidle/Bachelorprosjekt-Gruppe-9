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
    public class ProfilController : Controller
    {

        private MinSideContext db = new MinSideContext();



        // GET: Profil
        public ActionResult Index()
        {
            string id = Session["brukerID"].ToString();

            int brukerID;
            Int32.TryParse(id, out brukerID);

            var bruker = db.Brukere.Find(brukerID);

            return View(bruker);
        }

        // GET: Profil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profil/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profil/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profil/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Profil/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profil/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
