using İkinciElAracİhale.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Controllers
{
    public class KullaniciTanimlamaController : Controller
    {
        // GET: KullaniciTanimlama
        AracIhale db = new AracIhale();

        [Authorize]
        public ActionResult _KullaniciTanimlama()
        {
            List<Kullanici> kullaniciList = db.Kullanicis.ToList();
            return View(kullaniciList);
        }

        [HttpPost]
        public ActionResult KullaniciEkle(Kullanici yeniKullanici)
        {
            if (ModelState.IsValid)
            {

                db.Kullanicis.Add(yeniKullanici);
                db.SaveChanges();
                return RedirectToAction("_KullaniciTanimlama");
            }
            return View("_KullaniciTanimlama");
        }

        [HttpPost]
        public ActionResult DeleteKullanici(int KullaniciID)
        {
            var kullanici = db.Kullanicis.Find(KullaniciID);
            if (kullanici != null)
            {
                db.Kullanicis.Remove(kullanici);
                db.SaveChanges();
            }
            return RedirectToAction("_KullaniciTanimlama");
        }

        public ActionResult KullaniciDuzenle(int? KullaniciID)
        {
            if (KullaniciID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kullanici kullanici = db.Kullanicis.Find(KullaniciID);
            if (kullanici == null)
            {
                return HttpNotFound();
            }

            return View(kullanici);
        }

        [HttpPost]
        public ActionResult KullaniciGuncelle(Kullanici kullanici)
        {
            if (!ModelState.IsValid)
            {
                db.Kullanicis.Attach(kullanici);
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("_KullaniciTanimlama");
            }
            return View(kullanici);
        }

    }
}