﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace İkinciElAracİhale.UI.Models
{
    public partial class Aracİhale : DbContext
    {
        public Aracİhale()
            : base("name=Aracİhale")
        {
        }

        public virtual DbSet<AktifPasif> AktifPasifs { get; set; }
        public virtual DbSet<AracAliciBilgi> AracAliciBilgis { get; set; }
        public virtual DbSet<Araclar> Araclars { get; set; }
        public virtual DbSet<AracOzellik> AracOzelliks { get; set; }
        public virtual DbSet<AracParcaBilgi> AracParcaBilgis { get; set; }
        public virtual DbSet<AracParcaDurumu> AracParcaDurumus { get; set; }
        public virtual DbSet<AracTarihce> AracTarihces { get; set; }
        public virtual DbSet<BireyselAracTeklif> BireyselAracTeklifs { get; set; }
        public virtual DbSet<BireyselKurumsal> BireyselKurumsals { get; set; }
        public virtual DbSet<GovdeTipi> GovdeTipis { get; set; }
        public virtual DbSet<IhaleArac> IhaleAracs { get; set; }
        public virtual DbSet<IhaleListesi> IhaleListesis { get; set; }
        public virtual DbSet<IhaleStatu> IhaleStatus { get; set; }
        public virtual DbSet<IlanBilgi> IlanBilgis { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<KurumsalUyeOnay> KurumsalUyeOnays { get; set; }
        public virtual DbSet<OdemeBilgisi> OdemeBilgisis { get; set; }
        public virtual DbSet<PaketParametre> PaketParametres { get; set; }
        public virtual DbSet<PaketTanimlama> PaketTanimlamas { get; set; }
        public virtual DbSet<Renk> Renks { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Statu> Status { get; set; }
        public virtual DbSet<TramerTutari> TramerTutaris { get; set; }
        public virtual DbSet<VitesTipi> VitesTipis { get; set; }
        public virtual DbSet<YakitTipi> YakitTipis { get; set; }
        public virtual DbSet<Yetki> Yetkis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BireyselKurumsal>()
                .HasMany(e => e.Araclars)
                .WithOptional(e => e.BireyselKurumsal)
                .HasForeignKey(e => e.BireyselKurumsalID);

            modelBuilder.Entity<BireyselKurumsal>()
                .HasMany(e => e.IhaleListesis)
                .WithOptional(e => e.BireyselKurumsal)
                .HasForeignKey(e => e.BireyselKurumsalID);
        }
    }
}
