using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İkinciElAracİhale.UI.Models.VM
{
    public class AracGuncellemeViewModel
    {
        public int AracID { get; set; }
        public string MarkaAdi { get; set; }
        public string ModelAdi { get; set; }
        public string Durum { get; set; }
        public string StatuAdi { get; set; }



        public Araclar Araclar { get; set; }
        public AracOzellik AracOzellik { get; set; }
        public IEnumerable<SelectListItem> BireyselKurumsalList { get; set; }
        public IEnumerable<SelectListItem> StatuList { get; set; }
        public IEnumerable<SelectListItem> AracMarkaList { get; set; }
        public IEnumerable<SelectListItem> AracModelList { get; set; }
    }
}