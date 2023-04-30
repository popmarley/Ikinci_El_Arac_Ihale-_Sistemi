﻿using İkinciElAracİhale.UI.Models;
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
            var viewModel = new AracListelemeViewModel
            {
                AraclarList = araclar,
                StatuList = aracRepo.GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi"),
                AracMarkaList = aracRepo.GetSelectList(db.AracMarkas.ToList(), "MarkaID", "MarkaAdi"),
                AracModelList = aracRepo.GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi"),
                BireyselKurumsalList = aracRepo.GetSelectList(db.BireyselKurumsals.ToList(), "BireselKurumsalID", "Durum")
            };
            return View(viewModel);
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

        [HttpPost]
        public ActionResult FiltreliAracListele(AracListelemeViewModel model)
        {
            var filtreliAraclar = aracRepo.GetFiltreliAraclar(model);
            model.AraclarList = filtreliAraclar;

            // SelectList özelliklerini tekrar doldurun
            model.AracMarkaList = aracRepo.GetSelectList(db.AracMarkas.ToList(), "MarkaID", "MarkaAdi");
            model.AracModelList = aracRepo.GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi");
            model.BireyselKurumsalList = aracRepo.GetSelectList(db.BireyselKurumsals.ToList(), "BireselKurumsalID", "Durum");
            model.StatuList = aracRepo.GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi");

            return View("_AracListeleme", model);
        }
    }
}