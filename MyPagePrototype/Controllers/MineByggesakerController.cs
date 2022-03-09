using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPagePrototype.Models;

namespace MyPagePrototype.Controllers
{
    public class MineByggesakerController : Controller
    {



        // GET: Byggesaker
        public ActionResult Index()
        {

            Sak sak = new Sak(1, "Eier", "10.12.2020", "Test", "Dette er en test", "Nei takk");

            var model = sak.byggesaker.ToList();

            /* Tror vi trenger en Ienum ,, er nok enklere å bare implimentere entity framework */
            return View(model);
            

        }

        // GET: Byggesaker/Details/5
        public ActionResult Detaljer(int id)
        {
            return View();
        }

        public ActionResult Oppsummering()
        {
            return View();
        }


        // GET: Byggesaker/Create
        public ActionResult RegistrerSak()
        {
            return View();
        }

        // POST: Byggesaker/Create
        [HttpPost]
        public ActionResult RegistrerSak(FormCollection collection)
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
    }

}

