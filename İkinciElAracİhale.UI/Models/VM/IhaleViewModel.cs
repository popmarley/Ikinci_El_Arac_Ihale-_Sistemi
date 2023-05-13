using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Models.VM
{
    public class IhaleViewModel
    {

        public List<Araclar> Araclar { get; set; }
        public List<AracOzellik> AracOzellik { get; set; }
        public IhaleListesi IhaleListesi { get; set; }


        // IhaleArac alanları
        public int IhaleAracID { get; set; }
        public int? IhaleID { get; set; }
        public int? AracID { get; set; }
        public string IhaleBaslangicFiyati { get; set; }
        public string MinimumAlimFiyati { get; set; }

        // IhaleListesi alanları
        public int IhaleListesiID { get; set; }
        public string IhaleAdi { get; set; }
        public int? BireyselKurumsalID { get; set; }
        public string KurumsalSirketAdi { get; set; }
        public int? IhaleStatuID { get; set; }
        public string IhaleBaslangicTarihi { get; set; }
        public string IhaleBaslangicSaati { get; set; }
        public string IhaleBitisTarihi { get; set; }
        public string IhaleBitisSaati { get; set; }


        public List<Araclar> AraclarListesi { get; set; }
        public List<IhaleListesi> IhaleListesis { get; set; }
        public List<AracOzellik> AracOzellikListesi { get; set; }
        public IEnumerable<SelectListItem> PlakaList { get; set; }
        public IEnumerable<SelectListItem> BireyselKurumsalList { get; set; }
        public IEnumerable<SelectListItem> IhaleStatuList { get; set; }


    }
}