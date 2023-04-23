namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IhaleArac")]
    public partial class IhaleArac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IhaleArac()
        {
            BireyselAracTeklifs = new HashSet<BireyselAracTeklif>();
        }

        public int IhaleAracID { get; set; }

        public int? IhaleID { get; set; }

        public int? AracID { get; set; }

        [StringLength(50)]
        public string IhaleBaslangicFiyati { get; set; }

        [StringLength(50)]
        public string MinimumAlimFiyati { get; set; }

        public virtual Araclar Araclar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BireyselAracTeklif> BireyselAracTeklifs { get; set; }

        public virtual IhaleListesi IhaleListesi { get; set; }
    }
}
