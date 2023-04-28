using İkinciElAracİhale.UI.Models;
using İkinciElAracİhale.UI.Models.DAL;
using İkinciElAracİhale.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        AracIhale db = new AracIhale();
        private AracListeleme aracRepo;

        public AdminPanelController()
        {
            aracRepo = new AracListeleme();
        }

        public ActionResult _AracListeleme()
        {
            var araclar = aracRepo.GetAraclar();
            return View(araclar);
        }

        public ActionResult _AracDetayBilgisi()
        {
            var vm = aracRepo.GetAracDetayViewModel();
            return View(vm);
        }

        public ActionResult _İlanBilgileri()
        {
            return View();
        }

        public ActionResult _TramerBilgileri()
        {
            return View();
        }
        public ActionResult _BireyselArac()
        {
            return View();
        }

        public ActionResult _BireyselAracGuncelle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AracDetayKaydet(Araclar arac, AracOzellik aracOzellik)
        {
            if (!ModelState.IsValid)
            {
                // Hata mesajı göster veya hatalı alanları düzeltmek için kullanıcıyı yönlendir
                return View("_AracDetayBilgisi");
            }
            // Araç ve AracOzellik nesnelerini veritabanına kaydedin
            arac.AracOzellik = aracOzellik; // AracOzellik nesnesini Araclar nesnesine bağlayın
            aracRepo.SaveAracDetay(arac);
            return RedirectToAction("_AracDetayBilgisi");
        }

    }
}