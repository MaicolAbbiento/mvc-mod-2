﻿using mvc_mod_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_mod_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class adminController : Controller
    {
        // GET: admincontroller

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
            Ordini p = new Ordini();
            p.getqeury(1);
            return View();
        }

        public JsonResult Getquery1()
        {
            Ordini p = new Ordini();
            p.getqeury(1);
            List<Ordini> o = p.ordini;
            foreach (Ordini ordini1 in o)
            {
                ordini1.DataSpedizionestring = ordini1.Dataspedizione.ToShortDateString();
                ordini1.DataConsegnastring = ordini1.Datecosegna.ToShortDateString();
                ordini1.costoString = String.Format("{0:C}", ordini1.costo);
            }

            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Getquery2()
        {
            Ordini p = new Ordini();
            p.getqeury(2);
            List<Ordini> o = p.ordini;
            foreach (Ordini ordini1 in o)
            {
                ordini1.DataSpedizionestring = ordini1.Dataspedizione.ToShortDateString();
                ordini1.DataConsegnastring = ordini1.Datecosegna.ToShortDateString();
                ordini1.costoString = String.Format("{0:C}", ordini1.costo);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Getquery3()
        {
            Ordini p = new Ordini();
            p.query3();

            return Json(p.ordini, JsonRequestBehavior.AllowGet);
        }
    }
}