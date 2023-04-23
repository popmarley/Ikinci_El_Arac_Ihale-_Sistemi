namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AracAliciBilgi")]
    public partial class AracAliciBilgi
    {
        [Key]
        public int AliciID { get; set; }

        public int? AracID { get; set; }

        public int? KullaniciID { get; set; }

        public virtual Araclar Araclar { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
