namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TramerTutari")]
    public partial class TramerTutari
    {
        [Key]
        public int TramerID { get; set; }

        public int? AracID { get; set; }

        [StringLength(50)]
        public string Tutar { get; set; }

        public virtual Araclar Araclar { get; set; }
    }
}
