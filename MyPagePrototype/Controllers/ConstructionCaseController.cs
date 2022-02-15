using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers
{
    public class ConstructionCaseController : Controller
    {
        // GET: ConstructionCase
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConstructionCase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ConstructionCase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConstructionCase/Create
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

        // GET: ConstructionCase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConstructionCase/Edit/5
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

        // GET: ConstructionCase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConstructionCase/Delete/5
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
