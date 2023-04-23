namespace İkinciElAracİhale.UI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaketParametre")]
    public partial class PaketParametre
    {
        [Key]
        public int ParametreID { get; set; }

        public int? PaketID { get; set; }

        [StringLength(50)]
        public string AylikİhaleyeCikabilecekAracSayisi { get; set; }

        [StringLength(50)]
        public string AylikAlimYapanKurumsalSirketlerİcinKomisyonTutari { get; set; }

        public virtual PaketTanimlama PaketTanimlama { get; set; }
    }
}
