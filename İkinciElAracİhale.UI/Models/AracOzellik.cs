namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AracOzellik")]
    public partial class AracOzellik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AracOzellik()
        {
            Araclars = new HashSet<Araclar>();
        }

        public int AracOzellikID { get; set; }

        public int? AracMarkaID { get; set; }

        public int? YilID { get; set; }

        public int? AracModelID { get; set; }

        public int? GovdeTipiID { get; set; }

        public int? YakitTipiID { get; set; }

        public int? VitesTipiID { get; set; }

        [StringLength(50)]
        public string Versiyon { get; set; }

        public int? RenkID { get; set; }

        [StringLength(50)]
        public string OpsiyonelDonanim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Araclar> Araclars { get; set; }

        public virtual AracMarka AracMarka { get; set; }

        public virtual AracModel AracModel { get; set; }

        public virtual GovdeTipi GovdeTipi { get; set; }

        public virtual Renk Renk { get; set; }

        public virtual VitesTipi VitesTipi { get; set; }

        public virtual YakitTipi YakitTipi { get; set; }

        public virtual Yil Yil { get; set; }
    }
}
