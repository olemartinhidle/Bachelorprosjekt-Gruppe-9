using MyPagePrototype.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyPagePrototype.DAL
{
    public class MinSideContext : DbContext
    {

        public MinSideContext() : base("MinSideContext")
        {
        }

        // Setter opp tabell samlingene
        public DbSet<Melding> Meldinger { get; set; }
        public DbSet<Kvittering> Kvitteringer { get; set; }
        public DbSet<Byggesak> Byggesaker { get; set; }

        public DbSet<Innboks> Innboks { get; set; }
        public DbSet<ByggesakInnboks> ByggesakInnboks { get; set; }

        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<KontaktInfo> KontaktInfo { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            var byggesak = modelBuilder.Entity<Byggesak>();

            byggesak.HasOptional(o => o.Kvittering);
            byggesak.HasKey(k => k.ByggesakID);


            var kontaktinfo = modelBuilder.Entity<KontaktInfo>();

            kontaktinfo.HasOptional(o => o.Kvittering);
            kontaktinfo.HasKey(k => k.KontaktInfoID);

            var kvittering = modelBuilder.Entity<Kvittering>();

            kvittering.HasRequired(r => r.Byggesak);
            kvittering.HasRequired(r => r.KontaktInfo);
            kvittering.HasKey(k => k.KvitteringID);
            //kvittering.HasKey(k => new { k.ByggesakID, k.KontaktInfoID });
            











            /*
                        .HasRequired(s => s.Byggesak)
                        .WithRequiredPrincipal(ad => ad.Byggesak);
            */







            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();




        }

    }
}