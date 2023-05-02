using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Models.VM
{
    public class AracListelemeViewModel
    {
        public List<Araclar> AraclarList { get; set; }
        public List<AracOzellik> AracOzellikList { get; set; }
        public string AracMarka { get; set; }
        public string AracModel { get; set; }
        public string BireyselKurumsal { get; set; }
        public string Statu { get; set; }
        public string KullaniciAdi { get; set; }

        public SelectList AracMarkaList { get; set; }
        public SelectList AracModelList { get; set; }
        public SelectList BireyselKurumsalList { get; set; }
        public SelectList StatuList { get; set; }
        public SelectList KullaniciList { get; set; }


    }
}