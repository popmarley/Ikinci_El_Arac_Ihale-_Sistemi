namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AracParcaDurumu")]
    public partial class AracParcaDurumu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AracParcaDurumu()
        {
            AracParcaBilgis = new HashSet<AracParcaBilgi>();
        }

        [Key]
        public int AracParcaDurumID { get; set; }

        [StringLength(50)]
        public string DurumAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AracParcaBilgi> AracParcaBilgis { get; set; }
    }
}
