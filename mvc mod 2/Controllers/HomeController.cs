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

            return RedirectToAction("spedizioni", "Ordini");
        }

        [HttpGet]
        public ActionResult sigin()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult sigin([Bind(Exclude = "Admin,Errore")] Utente p)
        {
            if (ModelState.IsValid)
            {
                Utente utente = new Utente();
                utente.addDb(p);
            }
            return RedirectToAction("spedizioni", "Ordini");
        }
    }
}