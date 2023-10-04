using mvc_mod_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvc_mod_2.Controllers
{
    public class OrdiniController : Controller
    {
        [Authorize]
        public ActionResult spedizioni()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPersonByNome(string numerospedizione)
        {
            Ordini ordini = new Ordini();
            if (numerospedizione == "")
            {
                numerospedizione = "0";
            }
            ordini.Id = Convert.ToInt32(numerospedizione);
            ordini.codicefiscale = User.Identity.Name;
            List<Ordini> o = ordini.getspedizione(ordini);
            foreach (Ordini ordini1 in o)
            {
                ordini1.DataSpedizionestring = ordini1.Dataspedizione.ToShortDateString();
                ordini1.DataConsegnastring = ordini1.Datecosegna.ToShortDateString();
                ordini1.costoString = String.Format("{0:C}", ordini1.costo);
            }
            return Json(o);
        }

       
    }
}