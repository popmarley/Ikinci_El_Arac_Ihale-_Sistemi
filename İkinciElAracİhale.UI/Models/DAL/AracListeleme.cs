using İkinciElAracİhale.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace İkinciElAracİhale.UI.Models.DAL
{
    public class AracListeleme
    {
        private AracIhale db;

        public AracListeleme()
        {
            db = new AracIhale();
        }

        public List<Araclar> GetAraclar()
        {
            return db.Araclars.Include(a => a.AracOzellik)
                              .Include(a => a.BireyselKurumsal)
                              .Include(a => a.Statu)
                              .ToList();
        }

        public SelectList GetSelectList<T>(IEnumerable<T> items, string valueFieldName, string textFieldName)
        {
            return new SelectList(items, valueFieldName, textFieldName);
        }

        public AracDetayViewModel GetAracDetayViewModel()
        {
            return new AracDetayViewModel
            {
                BireyselKurumsalList = GetSelectList(db.BireyselKurumsals.ToList(), "BireselKurumsalID", "Durum"),
                StatuList = GetSelectList(db.Status.ToList(), "StatuID", "StatuAdi"),
                AracMarkaList = GetSelectList(db.AracMarkas.ToList(), "MarkaID", "MarkaAdi"),
                AracModelList = GetSelectList(db.AracModels.ToList(), "AracModelID", "ModelAdi"),
                GovdeTipiList = GetSelectList(db.GovdeTipis.ToList(), "GovdeTipiID", "GovdeTipiAdi"),
                YilList = GetSelectList(db.Yils.ToList(), "YilID", "Yil1"),
                YakitTipiList = GetSelectList(db.YakitTipis.ToList(), "YakitTipiID", "YakitTipiAdi"),
                VitesTipiList = GetSelectList(db.VitesTipis.ToList(), "VitesTipiID", "VitesTipiAdi"),
                RenkList = GetSelectList(db.Renks.ToList(), "RenkID", "RenkAdi")
            };
        }

        public void SaveAracDetay(Araclar arac)
        {
            db.Araclars.Add(arac);
            db.SaveChanges();
        }
    }
}
