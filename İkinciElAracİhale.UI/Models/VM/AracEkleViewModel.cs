using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Models.VM
{
    public class AracEkleViewModel
    {

        public Araclar Araclar { get; set; }
        public AracOzellik AracOzellik { get; set; }
        public int AracOzellikID { get; set; }
        public int GirisID { get; set; }
        public int AracMarkaID { get; set; }
        public int? AracID { get; set; }
        public int? BireyselKurumsalID { get; set; }
        public string KurumsalSirketAdi { get; set; }
        public string Versiyon { get; set; }
        public int? StatuID { get; set; }
        public int? AracGorselID { get; set; }
        public DateTime Tarih { get; set; }
        public string AracFiyati { get; set; }
        public string MarkaAdi { get; set; }
        public string ModelAdi { get; set; }
        public string Durum { get; set; }
        public string StatuAdi { get; set; }
        public string KullaniciAdi { get; set; }      
        public string BireyselKurumsal { get; set; }
        public string Statu { get; set; }
        public string KMBilgisi { get; set; }
        public string Donanim { get; set; }
        public int YilID { get; set; }
        public int AracModelID { get; set; }
        public int GovdeTipiID { get; set; }
        public int YakitTipiID { get; set; }
        public int VitesTipiID { get; set; }
        public int? RenkID { get; set; }



        public SelectList AracMarkaList { get; set; }
        public SelectList AracModelList { get; set; }
        public SelectList BireyselKurumsalList { get; set; }
        public SelectList StatuList { get; set; }

    }
}