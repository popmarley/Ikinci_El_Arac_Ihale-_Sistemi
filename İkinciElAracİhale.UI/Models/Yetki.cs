namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yetki")]
    public partial class Yetki
    {
        public int YetkiID { get; set; }

        public int? RolID { get; set; }

        [StringLength(50)]
        public string EkranAdi { get; set; }

        [StringLength(50)]
        public string İslemAdi { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
