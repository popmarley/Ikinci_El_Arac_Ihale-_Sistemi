namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OdemeBilgisi")]
    public partial class OdemeBilgisi
    {
        [Key]
        public int OdemeID { get; set; }

        public int? KullaniciID { get; set; }

        public int? IhaleID { get; set; }

        [StringLength(50)]
        public string OdemeTutari { get; set; }

        [StringLength(50)]
        public string OdemeTarihi { get; set; }

        [StringLength(50)]
        public string OdemeTipi { get; set; }

        [StringLength(50)]
        public string OdemeDurumu { get; set; }

        public virtual IhaleListesi IhaleListesi { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
