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
    }
}