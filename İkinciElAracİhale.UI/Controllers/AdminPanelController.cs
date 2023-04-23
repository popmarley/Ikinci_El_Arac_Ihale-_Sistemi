using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        public ActionResult _AracListeleme()
        {
            return View();
        }
        public ActionResult _AracDetayBilgisi()
        {
            return View();
        }

        public ActionResult _İlanBilgileri()
        {
            return View();
        }

        public ActionResult _TramerBilgileri()
        {
            return View();
        }

        public ActionResult _PaketTanimlama()
        {
            return View();
        }

        public ActionResult _KullaniciTanimlama()
        {
           return View();
        }

        public ActionResult _İhaleListeleme()
        {
            return View();
        }

        public ActionResult _YeniİhaleOlustur()
        {
            return View();
        }
    }
}