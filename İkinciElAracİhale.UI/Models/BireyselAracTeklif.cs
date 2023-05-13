namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BireyselAracTeklif")]
    public partial class BireyselAracTeklif
    {
        [Key]
        public int TeklifID { get; set; }

        public int? KullaniciID { get; set; }

        public int? IhaleAracID { get; set; }

        [StringLength(50)]
        public string TeklifFiyati { get; set; }

        [StringLength(50)]
        public string TeklifTarihi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
