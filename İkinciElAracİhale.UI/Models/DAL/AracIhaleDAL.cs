using İkinciElAracİhale.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Models.DAL
{
    public class AracIhaleDAL
    {
        private AracIhale db;

        public AracIhaleDAL()
        {
            db = new AracIhale();
        }

        public SelectList GetSelectList<T>(IEnumerable<T> items, string valueFieldName, string textFieldName)
        {
            return new SelectList(items, valueFieldName, textFieldName);
        }

        public IhaleViewModel GetIhaleViewModel()
        {
            return new IhaleViewModel
            {

                Araclar = db.Araclars.ToList(),
                AracOzellik = db.AracOzelliks.ToList(),
                IhaleListesis = db.IhaleListesis.Include(i => i.Araclar).Include(i => i.AracOzellik).ToList(),
                AraclarListesi = db.Araclars.ToList(),
                AracOzellikListesi = db.AracOzelliks.ToList(),
                PlakaList = GetSelectList(db.Araclars.ToList(), "AracID", "Plaka"),
                BireyselKurumsalList = GetSelectList(db.BireyselKurumsals.ToList(), "BireselKurumsalID", "Durum"),
                IhaleStatuList = GetSelectList(db.IhaleStatus.ToList(), "IhaleStatuID", "IhaleStatuAdi"),
            };
        }

        public void SaveAracIhale(IhaleListesi liste)
        {
            using (var dbContext = new AracIhale())
            {
                dbContext.IhaleListesis.Add(liste);
                dbContext.SaveChanges();
            }
        }

        public void DeleteAracIhale(int ihaleId)
        {
            using (var dbContext = new AracIhale())
            {
                var ihale = dbContext.IhaleListesis.Find(ihaleId);
                if (ihale != null)
                {
                    // İlgili BireyselAracTeklif kayıtlarını sil
            var bireyselTeklifler = dbContext.BireyselAracTeklifs.Where(t => t.IhaleID == ihaleId);
            dbContext.BireyselAracTeklifs.RemoveRange(bireyselTeklifler);
            
            // IhaleListesi'ndeki kaydı sil
            dbContext.IhaleListesis.Remove(ihale);
            dbContext.SaveChanges();
                }
            }
        }

        public List<IhaleListesi> GetFiltreliIhaleListes(IhaleViewModel model)
        {
            var ihaleler = db.IhaleListesis.AsQueryable();

            // Filtrelemeleri burada yapabiliriz.
            if (!string.IsNullOrEmpty(model.IhaleAdi))
            {
                ihaleler = ihaleler.Where(i => i.IhaleAdi.Contains(model.IhaleAdi));
            }

            if (model.BireyselKurumsalID.HasValue)
            {
                ihaleler = ihaleler.Where(i => i.BireyselKurumsalID == model.BireyselKurumsalID.Value);
            }

            if (model.IhaleStatuID.HasValue)
            {
                ihaleler = ihaleler.Where(i => i.IhaleStatuID == model.IhaleStatuID.Value);
            }

            // Daha fazla filtreleme eklenebilir.

            return ihaleler.ToList();
        }

    }

}
