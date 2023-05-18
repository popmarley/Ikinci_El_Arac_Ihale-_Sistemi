using İkinciElAracİhale.UI.Models;
using İkinciElAracİhale.UI.Models.DAL;
using İkinciElAracİhale.UI.Models.VM;
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

        private AracIhale db;
        private AracIhaleDAL ihaleDAL;

        public IhaleListelemeController()
        {
            db = new AracIhale();
            ihaleDAL = new AracIhaleDAL();

        }

        [Authorize]
        public ActionResult _IhaleListeleme()
        {
            // Tüm ihalenin listesi
            var ihaletList = db.IhaleListesis.ToList() ?? new List<IhaleListesi>();
            IhaleViewModel ihaleViewModel = new IhaleViewModel
            {
                IhaleListesis = ihaletList
            };

            // IhaleViewModel nesnesini görünüme geçir
            return View(ihaleViewModel);
        }

        [Authorize]
        public ActionResult _YeniİhaleOlustur()
        {

            var ihaleViewModel = ihaleDAL.GetIhaleViewModel();
            ihaleViewModel.IhaleStatuList = ihaleDAL.GetSelectList(db.IhaleStatus.ToList(), "IhaleStatuID", "IhaleStatuAdi");
            return View(ihaleViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult _YeniİhaleOlustur(IhaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // AracID'ye göre Araç nesnesini bul
                var arac = db.Araclars.FirstOrDefault(a => a.AracID == model.AracID);

                // Araç nesnesini bulamazsak hata döndür
                if (arac == null)
                {
                    ModelState.AddModelError("", "Geçersiz Araç ID");
                    return View(model);
                }

                // İhaleViewModel'den IhaleListesi nesnesine veri aktarımı
                IhaleListesi ihale = new IhaleListesi
                {
                    AracID = model.AracID,
                    AracOzellikID = arac.AracOzellikID, // Burada AracOzellikID'yi ata
                    IhaleAdi = model.IhaleAdi,
                    IhaleBaslangicFiyati = model.IhaleBaslangicFiyati,
                    MinimumAlimFiyati = model.MinimumAlimFiyati,
                    BireyselKurumsalID = model.BireyselKurumsalID,
                    KurumsalSirketAdi = model.KurumsalSirketAdi,
                    IhaleStatuID = model.IhaleStatuID,
                    IhaleBaslangicTarihi = model.IhaleBaslangicTarihi,
                    IhaleBitisTarihi = model.IhaleBitisTarihi,
                    IhaleBaslangicSaati = model.IhaleBaslangicSaati,
                    IhaleBitisSaati = model.IhaleBitisSaati
                };

                // IhaleListesi'nin kaydedilmesi
                ihaleDAL.SaveAracIhale(ihale);

                return RedirectToAction("_IhaleListeleme");
            }

            // Eğer ModelState geçersizse, hata mesajlarıyla birlikte aynı sayfayı tekrar göster
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Sil(int id)
        {
            ihaleDAL.DeleteAracIhale(id);
            return RedirectToAction("_IhaleListeleme");
        }


        [HttpPost]
        [Authorize]
        public ActionResult _IhaleListeleme(IhaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ihaletList = ihaleDAL.GetFiltreliIhaleListes(model);
                model.IhaleListesis = ihaletList;
                return View(model);
            }
            else
            {
                // Hata durumunda, hata mesajlarıyla birlikte modeli görünüme geri döndür.
                return View(model);
            }
        }
    }



}





