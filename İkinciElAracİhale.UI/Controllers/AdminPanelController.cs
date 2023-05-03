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

        [Authorize]
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

        [Authorize]
        public ActionResult _AracDetayBilgisi()
        {
            var vm = aracRepo.GetAracDetayViewModel();
            return View(vm);
        }

        [Authorize]
        public ActionResult _AracGuncelleme()
        {
            var vm = aracRepo.GetAracDetayViewModel();
            return View(vm);
        }



        [Authorize]
        public ActionResult _İlanBilgileri()
        {
            if (TempData["AracDetay"] != null)
            {
                AracDetayViewModel model = TempData["AracDetay"] as AracDetayViewModel;
                return RedirectToAction("IlanBilgileriKaydet", model);
            }

            return View();
        }

        [Authorize]
        public ActionResult _TramerBilgileri()
        {
            return View();
        }

        [Authorize]
        public ActionResult _BireyselArac()
        {
            return View();
        }

        [Authorize]
        public ActionResult _BireyselAracGuncelle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AracDetayKaydet(AracDetayViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["AracDetayViewModel"] = model;
                return RedirectToAction("_İlanBilgileri");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult FiltreliAracListele(AracListelemeViewModel model)
        {
            var filtreliAraclar = aracRepo.GetFiltreliAraclar(model);
            model.AraclarList = filtreliAraclar;

            // SelectList özelliklerini tekrar doldurduk
            model.AracMarkaList = aracRepo.GetSelectList(db.AracMarkas.ToList(), "MarkaID", "MarkaAdi");
            model.AracModelList = aracRepo.GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi");
            model.BireyselKurumsalList = aracRepo.GetSelectList(db.BireyselKurumsals.ToList(), "BireselKurumsalID", "Durum");
            model.StatuList = aracRepo.GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi");

            return View("_AracListeleme", model);
        }

        [Authorize]
        public ActionResult AracSil(int id)
        {
            var arac = db.Araclars.FirstOrDefault(a => a.AracID == id);

            if (arac != null)
            {
                var aracOzellik = db.AracOzelliks.FirstOrDefault(o => o.AracOzellikID == arac.AracOzellikID);// İlk olarak bağlantılı AracOzellik nesnesini siliyoruz
                if (aracOzellik != null)
                {
                    db.AracOzelliks.Remove(aracOzellik);
                    db.SaveChanges();
                }

                db.Araclars.Remove(arac);  // Ardından aracı siliyoruz
                db.SaveChanges();
            }

            return RedirectToAction("_AracListeleme");
        }

        /////
        ///
        [HttpGet]
        public ActionResult AracGuncelle(int id)
        {
            var dal = new AracListeleme();
            var arac = dal.GetAraclar().FirstOrDefault(a => a.AracID == id);

            if (arac == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AracDetayViewModel
            {
                Araclar = arac,
                BireyselKurumsalList = dal.GetSelectList(db.BireyselKurumsals.ToList(), "BireselKurumsalID", "Durum"),
                StatuList = dal.GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi"),
                AracMarkaList = dal.GetSelectList(db.AracMarkas.ToList(), "MarkaID", "MarkaAdi"),
                AracModelList = dal.GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi"),
            };

            return View("_AracGuncelleme", viewModel);
        }

        [HttpPost]
        public ActionResult AracGuncelle(AracDetayViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new AracIhale())
                {
                    var aracToUpdate = dbContext.Araclars.Find(model.Araclar.AracID);
     
                    aracToUpdate.AracOzellik.AracMarkaID = model.Araclar.AracOzellik.AracMarkaID;
                    aracToUpdate.AracOzellik.AracModelID = model.Araclar.AracOzellik.AracModelID;
                    aracToUpdate.BireyselKurumsalID = model.Araclar.BireyselKurumsalID;
                    aracToUpdate.StatuID = model.Araclar.StatuID;
                    aracToUpdate.Tarih= DateTime.Now;
                    dbContext.Entry(aracToUpdate).State = EntityState.Modified;
                    
                    dbContext.SaveChanges();
                }

                return RedirectToAction("_AracListeleme");
            }

            return View("_AracGuncelleme", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlanBilgileriKaydet(AracDetayViewModel model)
        {
            if (ModelState.IsValid)
            {
                // İlan bilgilerini kaydetmek için işlemleri burada gerçekleştirin.
                if (TempData["AracDetayViewModel"] is AracDetayViewModel aracDetay)
                {
                    // TempData'dan alınan bilgileri Araclar ve AracOzellik nesnelerine aktarın.
                    model.Araclar = aracDetay.Araclar;
                    model.AracOzellik = aracDetay.AracOzellik;

                    // Araclar ve AracOzellik nesnelerini veritabanına kaydedin.
                    db.Araclars.Add(model.Araclar);
                    db.AracOzelliks.Add(model.AracOzellik);

                    // İlanBilgi nesnesi oluşturun ve veritabanına ekleyin.
                    IlanBilgi ilanBilgi = new IlanBilgi
                    {
                        IlanBasligi = model.IlanBasligi,
                        IlanAciklamasi = model.IlanAciklamasi,
                        AracID = model.Araclar.AracID, // AracID özelliği burada kullanılıyor
                                                       // Gerekirse diğer alanları da buraya ekleyin.
                    };
                    db.IlanBilgis.Add(ilanBilgi);
                    model.Araclar.AracOzellikID = model.AracOzellik.AracOzellikID;
                    model.Araclar.Tarih = DateTime.Now;
                    // Değişiklikleri veritabanına kaydedin.
                    db.SaveChanges();
                }

                // Önceki sayfaya geri dönmek için:
                return RedirectToAction("_AracDetayBilgisi");
            }

            // Model doğrulama başarısızsa, kullanıcıyı aynı sayfada tutun ve hataları gösterin.
            return View("_İlanBilgileri", model);
        }
    }


}