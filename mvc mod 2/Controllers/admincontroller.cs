using mvc_mod_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_mod_2.Controllers
{
    public class adminController : Controller
    {
        // GET: admincontroller
        [Authorize(Roles = "Admin")]
        public ActionResult gestionespedizioni()
        {
            Ordini ordini = new Ordini();
            List<Ordini> o = ordini.getAllspedizioni();
            return View(o);
        }

        public ActionResult eliminadaldatabase(string parameter)
        {
            int ID = Convert.ToInt32(parameter);
            Ordini o = new Ordini();
            o.elminaOrdine(ID);
            return RedirectToAction("gestionespedizioni");
        }

        public ActionResult dettagliprodotto(int id)
        {
            Ordini o = new Ordini();
            o = o.getspedizione(id);
            o.DataSpedizionestring = o.Dataspedizione.ToShortDateString();
            o.DataConsegnastring = o.Datecosegna.ToShortDateString();
            return View(o);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Ordini o = new Ordini();
            o = o.getspedizione(id);
            o.DataSpedizionestring = o.Dataspedizione.ToShortDateString();
            o.DataConsegnastring = o.Datecosegna.ToShortDateString();
            return View(o);
        }

        [HttpPost]
        public ActionResult Edit(Ordini p)
        {
            if (ModelState.IsValid)
            {
                Ordini o = new Ordini();
                try
                {
                    p.Dataspedizione = Convert.ToDateTime(p.DataSpedizionestring);
                }
                catch { ViewBag.dataSpedizione = "inserire una data"; }
                try
                {
                    p.Datecosegna = Convert.ToDateTime(p.DataConsegnastring);
                }
                catch { ViewBag.dataconsega = "inserire una data"; }
                if (ViewBag.dataSpedizione != "inserire una data" || ViewBag.dataconsega != "inserire una data")
                {
                    o.modificaOrdine(p);
                }
            }
            return View();
        }

        public ActionResult queryPage()
        {

            return View();
        }

        public JsonResult Getquery1()
        {
            Ordini p = new Ordini();
            p.getqeury(1);

            return Json(p.ordini);
        }

        public JsonResult Getquery2()
        {
            Ordini p = new Ordini();
            p.getqeury(2);

            return Json(p.ordini);
        }

        public JsonResult Getquery3()
        {
            Ordini p = new Ordini();
            p.getqeury(2);

            return Json(p.ordini);
        }
    }
}