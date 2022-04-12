using MyPagePrototype.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyPagePrototype.DAL
{
    // Extender Db context klassen
    public class MinSideContext : DbContext
    {
        // Baseres på variabler i Web.config
        public MinSideContext() : base("MinSideContext")
        {
        }

        // Setter opp tabell samlingene
        public DbSet<Melding> Meldinger { get; set; }
        public DbSet<Kvittering> Kvitteringer { get; set; }
        public DbSet<Byggesak> Byggesaker { get; set; }
        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<KontaktInfo> KontaktInfo { get; set; }



        // Det som skjer når db genereres
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Setter opp forholdene
            // Setter Entitet til variabel for enklere bruk
            var byggesak = modelBuilder.Entity<Byggesak>();

            // Byggesak må ha bruker
            byggesak.HasRequired(r => r.Bruker);
            // Byggesak kan ha kvittering
            byggesak.HasOptional(o => o.Kvittering);
            // Har pri nøkkel ByggesakID
            byggesak.HasKey(k => k.ByggesakID);

           
            // Setter Entitet til variabel for enklere bruk
            var kontaktinfo = modelBuilder.Entity<KontaktInfo>();
            // Kontaktinfo må ha en bruker
            kontaktinfo.HasRequired(r => r.Bruker);
            // Kan ha en kvittering
            kontaktinfo.HasOptional(o => o.Kvittering);
            // Har pri nøkkel Kontaktinfo id
            kontaktinfo.HasKey(k => k.KontaktInfoID);


            // Setter Entitet til variabel for enklere bruk
            var kvittering = modelBuilder.Entity<Kvittering>();

            //En kvittering må ha Byggesak
            kvittering.HasRequired(r => r.Byggesak);
            // En kvittering må ha kontaktinfo
            kvittering.HasRequired(r => r.KontaktInfo);
            // Kvittering har pri nøkkel Kvittering ID
            kvittering.HasKey(k => k.KvitteringID);


            // Setter Entitet til variabel for enklere bruk
            var bruker = modelBuilder.Entity<Bruker>();
            // En bruker har mange kontaktinfo føringer
            bruker.HasMany(o => o.KontaktInfo);
            // En bruker har mange byggesaker
            bruker.HasMany(m => m.Byggesaker);
            // En bruker har mange meldinger
            bruker.HasMany(m => m.Meldinger);
            // Pri nøkkel er brukerID
            bruker.HasKey(k => k.BrukerID);          

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}