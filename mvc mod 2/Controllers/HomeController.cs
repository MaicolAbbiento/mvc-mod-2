using mvc_mod_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_mod_2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult login([Bind(Include = "codicefiscale,Password")] Utente p)
        {
            Utente utente = new Utente();
            utente.GetUtentet1(p);

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Ordini");
            }

            return View();
        }

        [HttpGet]
        public ActionResult sigin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sigin([Bind(Exclude = "Admin,Errore")] Utente p)
        {
            Utente utente = new Utente();
            utente.addDb(p);
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Ordini");
            }
            return View();
        }
    }
}