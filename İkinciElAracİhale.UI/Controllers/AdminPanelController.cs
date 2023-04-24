using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        AracIhale db= new AracIhale();
        public ActionResult _AracListeleme()
        {
            return View();
        }
        public ActionResult _AracDetayBilgisi()
        {
            var bireyselkurumsal = db.BireyselKurumsals.ToList();
            var status = db.Status.ToList();
            var aracmarkasi=db.AracMarkas.ToList();
            var aracmodeli=db.AracModels.ToList();
            var govdetipi=db.GovdeTipis.ToList();
            var yil=db.Yils.ToList();
            var yakittipi=db.YakitTipis.ToList();
            var vitestipi=db.VitesTipis.ToList();
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

        public ActionResult _PaketTanimlama()
        {
            return View();
        }

        public ActionResult _KurumsalUyeOnay()
        {
            return View();
        }

        public ActionResult _KurumsalUyeOnayDetay()
        {
            return View();
        }

        public ActionResult _KullaniciTanimlama()
        {
            List<Kullanici> kullaniciList = db.Kullanicis.ToList();
            return View(kullaniciList);
        }

        public ActionResult _İhaleListeleme()
        {
            return View();
        }

        public ActionResult _YeniİhaleOlustur()
        {
            return View();
        }

        public ActionResult _İhaleFiyat()
        {
            return View();
        }

        public ActionResult _Footer()
        {
            return View();
        }

        public ActionResult _Header()
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

        public ActionResult _KomisyonVeNoterUcretleri()
        {
            return View();
        }

        public ActionResult _StokYonetimi()
        {
            return View();
        }

        public ActionResult _StokYonetimiDetay()
        {
            return View();
        }

        public ActionResult _İhaleyeCikanAraclar()
        {
            return View();
        }

        public ActionResult _Rapor1()
        {
            return View();
        }

        public ActionResult _OrtaZorlukRapor()
        {
            return View();
        }

        public ActionResult _KompleksRapor()
        {
            return View();
        }

    }
}