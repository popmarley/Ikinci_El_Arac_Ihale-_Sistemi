namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RolMenu")]
    public partial class RolMenu
    {
        public int RolMenuID { get; set; }

        public int? RolID { get; set; }

        public int? MenuID { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
