namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AracParcaBilgi")]
    public partial class AracParcaBilgi
    {
        [Key]
        public int ParcaID { get; set; }

        public int? AracID { get; set; }

        [StringLength(50)]
        public string ParcaAdi { get; set; }

        public int? AracParcaDurumID { get; set; }

        public virtual Araclar Araclar { get; set; }

        public virtual AracParcaDurumu AracParcaDurumu { get; set; }
    }
}
