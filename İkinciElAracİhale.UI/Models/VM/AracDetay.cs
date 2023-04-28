using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using İkinciElAracİhale.UI.Models;

namespace İkinciElAracİhale.UI.Models.VM
{
    public class AracDetayViewModel
    {
        public Araclar Araclar { get; set; }
        public AracOzellik AracOzellik { get; set; }
        public IEnumerable<SelectListItem> BireyselKurumsalList { get; set; }
        public IEnumerable<SelectListItem> StatuList { get; set; }
        public IEnumerable<SelectListItem> AracMarkaList { get; set; }
        public IEnumerable<SelectListItem> AracModelList { get; set; }
        public IEnumerable<SelectListItem> GovdeTipiList { get; set; }
        public IEnumerable<SelectListItem> YilList { get; set; }
        public IEnumerable<SelectListItem> YakitTipiList { get; set; }
        public IEnumerable<SelectListItem> VitesTipiList { get; set; }
        public IEnumerable<SelectListItem> RenkList { get; set; }
    }
}