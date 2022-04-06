using MyPagePrototype.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MyPagePrototype.DAL
{

    public class MinSideInitializer : System.Data.Entity.DropCreateDatabaseAlways<MinSideContext>
    {
        protected override void Seed(MinSideContext context)
        {
            // ---------------------------------------------------------------//
            var brukere = new List<Bruker>
            {
            new Bruker{BrukerID=1, Navn="Normann, Ola Svendsen", Passord=123456, Telefonnummer="47474747", Epost="ola@mail.com"}

            };
            brukere.ForEach(u => context.Brukere.Add(u));
            context.SaveChanges();

            // ---------------------------------------------------------------//
            var meldinger = new List<Melding>
            //DateTime.Parse("2012-10-10")
            {
            new Melding{MeldingID= 1,MeldingDato=DateTime.Parse("2012-10-10"), MeldingTittel="Det er oppdaget en feil på din eiendom", MeldingAvsender="Kristiansand kommune", MeldingFilPath="/Resources/Byggesaksmelding.pdf", BrukerID=1},
            new Melding{MeldingID= 2,MeldingDato=DateTime.Parse("2012-10-10"), MeldingTittel="Det er oppdaget en feil på din eiendom", MeldingAvsender="Kristiansand kommune", MeldingFilPath="/Resources/Byggesaksmelding.pdf", BrukerID=1}
            };
            meldinger.ForEach(m => context.Meldinger.Add(m));
            context.SaveChanges();

            // ---------------------------------------------------------------//
            var byggesaker = new List<Byggesak>
            {
            new Byggesak{ByggesakID=1, ByggesakTema="Dette er tema", TypeBygg="Bolig", ByggningsNummer=2354, ByggesakTittel="Oppdaget uregistrert bygg på din eiendom", ByggesakDato=DateTime.Parse("2012-10-10"), ByggesakStatus="Ferdig behandlet", NæringsGruppe="Ikke oppgitt", NyHøyde=2, NyttAreal=6, KvitteringID=1, BrukerID=1},
            //new Byggesak{ByggesakID=2, ByggesakTema="Dette er tema", TypeBygg="Bolig", ByggningsNummer=2354, ByggesakTittel="Oppdaget uregistrert bygg på din eiendom", ByggesakDato=DateTime.Parse("2012-10-10"), ByggesakStatus="Ubehandlet", NæringsGruppe="Ikke oppgitt", NyHøyde=4, NyttAreal=8, KvitteringID=1},
            //new Byggesak{ByggesakID=12, ByggesakTittel="Oppdaget uregistrert bygg på din eiendom", ByggesakDato=DateTime.Parse("2012-10-10"), ByggesakStatus="Ferdig behandlet"},


            };

            byggesaker.ForEach(s => context.Byggesaker.Add(s));
            context.SaveChanges();

            // ---------------------------------------------------------------//
            
            var kontaktinfo = new List<KontaktInfo>
            {
            new KontaktInfo{KontaktInfoID=1, Navn="Ola", Telefonnummer="47474747", Epost="ola@mail.com", MailØnsket=true, Samtykke=true, BrukerID=1},
            //new KontaktInfo{KontaktInfoID=11, Navn="Jens Jenshus", Telefonnummer="47474747", Epost="Test@mail.com", MailØnsket=true, Samtykke=true},

            };
            kontaktinfo.ForEach(k => context.KontaktInfo.Add(k));
            context.SaveChanges();

            
            // ---------------------------------------------------------------//
            // DateTime.Parse("2012-10-10")
            var kvitteringer = new List<Kvittering>
            {
                            new Kvittering{KvitteringID=1, KvitteringsDato=DateTime.Parse("2012-10-10"), Kommentar="Kommentar til denne saken", Vedlegg="*Ingen vedlegg lagt til", MatrikkelPath="/Resources/Matrikkel/matrikkel.png", OrtoPath="/Resources/OrtoPhoto/orto.png", ByggesakID=1, KontaktInfoID=1},
                            //new Kvittering{KvitteringID=2, KvitteringsDato=DateTime.Now, Kommentar="Kommentar til denne saken", Vedlegg="/path/til/vedlegg", MatrikkelPath="/Resources/Matrikkel/matrikkel.png", OrtoPath="/Resources/OrtoPhoto/orto.png", ByggesakID=12, KontaktInfoID=11},
            };
            kvitteringer.ForEach(h => context.Kvitteringer.Add(h));
            context.SaveChanges();
        }
            // ---------------------------------------------------------------//
    }


// ---------------------------------------------------------------//
            /*var innboks = new List<Innboks>
                            {
                            new Innboks{BrukerID=1, MeldingID=1}
                            };
            innboks.ForEach(i => context.Innboks.Add(i));
            context.SaveChanges();*/

            // ---------------------------------------------------------------//
            /*var byggesakinnboks = new List<ByggesakInnboks>
            {
                            new ByggesakInnboks{BrukerID=1, ByggesakID=1}
                            };
            byggesakinnboks.ForEach(b => context.ByggesakInnboks.Add(b));
            context.SaveChanges();*/

}

