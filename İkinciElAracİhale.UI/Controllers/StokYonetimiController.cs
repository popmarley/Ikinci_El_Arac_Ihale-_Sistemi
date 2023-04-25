using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class StokYonetimiController : Controller
    {
        // GET: StokYonetimi
        AracIhale db = new AracIhale();
        public ActionResult _StokYonetimi()
        {
            return View();
        }

        public ActionResult _StokYonetimiDetay()
        {
            return View();
        }
    }
}