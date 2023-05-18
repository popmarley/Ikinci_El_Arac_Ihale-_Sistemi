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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BireyselAracTeklif()
        {
            OnaylananTeklifs = new HashSet<OnaylananTeklif>();
        }

        [Key]
        public int TeklifID { get; set; }

        public int? KullaniciID { get; set; }

        [StringLength(50)]
        public string TeklifFiyati { get; set; }

        public DateTime? TeklifTarihi { get; set; }

        public int? IhaleID { get; set; }

        public virtual IhaleListesi IhaleListesi { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OnaylananTeklif> OnaylananTeklifs { get; set; }
    }
}
