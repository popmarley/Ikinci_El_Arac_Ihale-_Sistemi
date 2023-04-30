using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class KomisyonVeNoterController : Controller
    {
        // GET: KomisyonVeNoter
        AracIhale db = new AracIhale();

        [Authorize]
        public ActionResult _KomisyonVeNoterUcretleri()
        {
            return View();
        }
    }
}