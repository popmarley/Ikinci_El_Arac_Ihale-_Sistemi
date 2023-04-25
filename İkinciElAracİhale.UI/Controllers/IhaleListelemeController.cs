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
        public ActionResult _IhaleListeleme()
        {
            return View();
        }

        public ActionResult _YeniİhaleOlustur()
        {
            return View();
        }

        public ActionResult _IhaleFiyat()
        {
            return View();
        }
    }
}