using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            return View();
        }

        // GET: Profil/Details/5
        public ActionResult Detaljer(int id)
        {
            return View();
        }

        // GET: Profil/Create
        public ActionResult RegistrerProfil()
        {
            return View();
        }

        // POST: Profil/Create
        [HttpPost]
        public ActionResult RegistrerProfil(FormCollection collection)
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
        public ActionResult RedigerProfil(int id)
        {
            return View();
        }

        // POST: Profil/Edit/5
        [HttpPost]
        public ActionResult RedigerProfil(int id, FormCollection collection)
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
        public ActionResult SlettProfil(int id)
        {
            return View();
        }

        // POST: Profil/Delete/5
        [HttpPost]
        public ActionResult SlettProfil(int id, FormCollection collection)
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
