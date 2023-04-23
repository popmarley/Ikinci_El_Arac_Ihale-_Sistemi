namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AracTarihce")]
    public partial class AracTarihce
    {
        [Key]
        public int TarihceID { get; set; }

        public int? AracID { get; set; }

        [StringLength(50)]
        public string Statu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public virtual Araclar Araclar { get; set; }
    }
}
