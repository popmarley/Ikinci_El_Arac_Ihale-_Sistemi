using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class IhaleListelemeController : Controller
    {
        // GET: IhaleListeleme
        AracIhale db = new AracIhale();

        [Authorize]
        public ActionResult _IhaleListeleme()
        {
            return View();
        }

        [Authorize]
        public ActionResult _YeniİhaleOlustur()
        {
            return View();
        }

        [Authorize]
        public ActionResult _IhaleFiyat()
        {
            return View();
        }
    }
}