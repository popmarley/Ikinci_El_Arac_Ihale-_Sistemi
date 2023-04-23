namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KurumsalUyeOnay")]
    public partial class KurumsalUyeOnay
    {
        [Key]
        public int OnayID { get; set; }

        public int? KullaniciID { get; set; }

        public int? PaketID { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public virtual PaketTanimlama PaketTanimlama { get; set; }
    }
}
