namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IlanBilgi")]
    public partial class IlanBilgi
    {
        [Key]
        public int IlanID { get; set; }

        public int? AracID { get; set; }

        [StringLength(50)]
        public string IlanBasligi { get; set; }

        public string IlanAciklamasi { get; set; }

        public virtual Araclar Araclar { get; set; }
    }
}
