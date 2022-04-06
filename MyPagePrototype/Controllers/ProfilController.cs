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

            Int32.TryParse(id, out int brukerID);

            var bruker = db.Brukere.Find(brukerID);

            return View(bruker);
        }

        // GET: Profil/Details/5
        public ActionResult Details(int id)
        {
            return View();
        } 
        
    }
}
