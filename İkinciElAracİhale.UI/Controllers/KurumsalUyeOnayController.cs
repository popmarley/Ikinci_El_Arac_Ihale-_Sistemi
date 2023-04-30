using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class KurumsalUyeOnayController : Controller
    {
        // GET: KurumsalUyeOnay
        AracIhale db = new AracIhale();

        [Authorize]
        public ActionResult _KurumsalUyeOnay()
        {
            return View();
        }
        [Authorize]
        public ActionResult _KurumsalUyeOnayDetay()
        {
            return View();
        }
    }
}