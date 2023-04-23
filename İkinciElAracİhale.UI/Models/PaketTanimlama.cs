namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaketTanimlama")]
    public partial class PaketTanimlama
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaketTanimlama()
        {
            KurumsalUyeOnays = new HashSet<KurumsalUyeOnay>();
            PaketParametres = new HashSet<PaketParametre>();
        }

        [Key]
        public int PaketID { get; set; }

        [StringLength(50)]
        public string PaketAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KurumsalUyeOnay> KurumsalUyeOnays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaketParametre> PaketParametres { get; set; }
    }
}
