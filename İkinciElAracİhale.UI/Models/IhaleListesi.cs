namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IhaleListesi")]
    public partial class IhaleListesi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IhaleListesi()
        {
            IhaleAracs = new HashSet<IhaleArac>();
            OdemeBilgisis = new HashSet<OdemeBilgisi>();
        }

        [Key]
        public int IhaleID { get; set; }

        [StringLength(50)]
        public string IhaleAdi { get; set; }

        public int? BireyselKurumsalID { get; set; }

        [StringLength(50)]
        public string KurumsalSirketAdi { get; set; }

        public int? IhaleStatuID { get; set; }

        [StringLength(50)]
        public string IhaleBaslangicTarihi { get; set; }

        [StringLength(50)]
        public string IhaleBaslangicSaati { get; set; }

        [StringLength(50)]
        public string IhaleBitisTarihi { get; set; }

        [StringLength(50)]
        public string IhaleBitisSaati { get; set; }

        public virtual BireyselKurumsal BireyselKurumsal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IhaleArac> IhaleAracs { get; set; }

        public virtual IhaleStatu IhaleStatu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OdemeBilgisi> OdemeBilgisis { get; set; }
    }
}
