using İkinciElAracİhale.UI.Models;
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
        
        public ActionResult _AracListeleme()
        {
            var araclar = db.Araclars.Include(a => a.AracOzellik)
                             .Include(a => a.BireyselKurumsal)
                             .Include(a => a.Statu)
                             .ToList();
            return View(araclar);
        }
        public ActionResult _AracDetayBilgisi()
        {
            var vm=new AracDetayViewModel();
            var bireyselkurumsal = db.BireyselKurumsals.ToList();
            var status = db.Status.ToList();
            var aracmarkasi = db.AracMarkas.ToList();
            var aracmodeli = db.AracModels.ToList();
            var govdetipi = db.GovdeTipis.ToList();
            var yil = db.Yils.ToList();
            var yakittipi = db.YakitTipis.ToList();
            var vitestipi = db.VitesTipis.ToList();
            var renk = db.Renks.ToList();


            ViewBag.BireyselKurumsalList = new SelectList(bireyselkurumsal, "BireselKurumsalID", "Durum");
            ViewBag.StatuList = new SelectList(status, "StatuID", "StatuAdi");
            ViewBag.AracMarkaList = new SelectList(aracmarkasi, "MarkaID", "MarkaAdi");
            ViewBag.AracModelList = new SelectList(aracmodeli, "AracModelID", "ModelAdi");
            ViewBag.GovdeTipiList = new SelectList(govdetipi, "GovdeTipiID", "GovdeTipiAdi");
            ViewBag.YilList = new SelectList(yil, "YilID", "Yil1");
            ViewBag.YakitTipiList = new SelectList(yakittipi, "YakitTipiID", "YakitTipiAdi");
            ViewBag.VitesTipiList = new SelectList(vitestipi, "VitesTipiID", "VitesTipiAdi");
            ViewBag.RenkList = new SelectList(renk, "RenkID", "RenkAdi");

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

        public ActionResult _BireyselArac()
        {
            return View();
        }
        public ActionResult _BireyselAracGuncelle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AracDetayKaydet(Araclar arac, AracOzellik aracOzellik)
        {
            if (!ModelState.IsValid)
            {
                // Hata mesajı göster veya hatalı alanları düzeltmek için kullanıcıyı yönlendir
                return View("_AracDetayBilgisi");
            }
            // Araç ve AracOzellik nesnelerini veritabanına kaydedin
            arac.AracOzellik = aracOzellik; // AracOzellik nesnesini Araclar nesnesine bağlayın
            db.Araclars.Add(arac);
            db.SaveChanges();
            return RedirectToAction("_AracDetayBilgisi");
        }
    }


}