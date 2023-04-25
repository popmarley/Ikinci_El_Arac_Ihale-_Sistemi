using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class PaketTanimlamaController : Controller
    {
        // GET: PaketTanimlama
        AracIhale db = new AracIhale();
        public ActionResult _PaketTanimlama()
        {
            return View();
        }
    }
}