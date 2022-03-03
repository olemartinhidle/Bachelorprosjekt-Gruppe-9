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

            var byggesaksliste = new List<Sak>();

            Sak sak = new Sak();

            sak.SakNr = 1;
            sak.Dato = "10.12.2020";
            sak.Tema = "Test";
            sak.Sakbeskjed = "Dette er en test";
            sak.Svar = "Nei takk";

            byggesaksliste.Add(sak);

            return View(byggesaksliste);
        }

        // GET: Byggesaker/Details/5
        public ActionResult Detaljer(int id)
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

