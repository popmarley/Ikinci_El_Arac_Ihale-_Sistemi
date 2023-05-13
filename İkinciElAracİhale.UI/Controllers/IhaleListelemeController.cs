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
            var ihaletList = db.IhaleListesis.ToList();
            return View(ihaletList);
        }

        [Authorize]
        public ActionResult _YeniİhaleOlustur()
        {

            var ihaleViewModel = ihaleDAL.GetIhaleViewModel();
            return View(ihaleViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult _YeniİhaleOlustur(IhaleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // İhaleViewModel'den IhaleListesi nesnesine veri aktarımı
                IhaleListesi ihale = new IhaleListesi
                {
                    AracID = model.AracID,
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

        
    }



}





