using MyPagePrototype.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MyPagePrototype.DAL
{
    // Bestemmer hva som skal skje med db mellom start slutt, her satt til å begynne på nytt hver gang
    public class MinSideInitializer : System.Data.Entity.DropCreateDatabaseAlways<MinSideContext>
    {
        private string Err;
        // Bestemmer data som skal settes inn i db ved start av prototype
        protected override void Seed(MinSideContext context)
        {
            try {
                // ---------------------------------------------------------------//
                // Setter liste med brukere
                var brukere = new List<Bruker>
            {
                // Fyller et nytt brukerobjekt
            new Bruker{BrukerID=1, Navn="Normann, Ola Svendsen", Passord="123456", Telefonnummer="47474747", Epost="ola@mail.com"}

            };
                // Legger til data fra hvert objekt
                brukere.ForEach(u => context.Brukere.Add(u));
                // Lagrer endringer
                context.SaveChanges();

                // ---------------------------------------------------------------//
                // Setter liste med meldinger
                var meldinger = new List<Melding>

            {
                // Fyller nye meldingsobjekt
            new Melding{MeldingID= 1,MeldingDato=DateTime.Parse("2012-10-10"), MeldingTittel="Det er oppdaget en feil på din eiendom", MeldingAvsender="Kristiansand kommune", MeldingFilPath="/Resources/Byggesaksmelding.pdf", BrukerID=1},
            new Melding{MeldingID= 2,MeldingDato=DateTime.Parse("2012-10-10"), MeldingTittel="Det er oppdaget en feil på din eiendom", MeldingAvsender="Kristiansand kommune", MeldingFilPath="/Resources/Byggesaksmelding.pdf", BrukerID=1}
            };
                // Legger til data fra hvert objekt
                meldinger.ForEach(m => context.Meldinger.Add(m));
                // Lagrer endringer
                context.SaveChanges();

                // ---------------------------------------------------------------//
                // Setter liste med byggesaker
                var byggesaker = new List<Byggesak>
            {
                // Fyller et nytt byggesaksobjekt
            new Byggesak{ByggesakID=1, ByggesakTema="Dette er tema", TypeBygg="Bolig", ByggningsNummer=2354, ByggesakTittel="Oppdaget uregistrert bygg på din eiendom", ByggesakDato=DateTime.Parse("2012-10-10"), ByggesakStatus="Ferdig behandlet", NæringsGruppe="Ikke oppgitt", NyHøyde=2, NyttAreal=6, KvitteringID=1, BrukerID=1},

            };
                // Legger til data fra hvert objekt
                byggesaker.ForEach(s => context.Byggesaker.Add(s));
                // Lagrer endringer
                context.SaveChanges();

                // ---------------------------------------------------------------//
                // Setter liste med kontaktinfo
                var kontaktinfo = new List<KontaktInfo>
            {
                // Fyller et nytt kontaktinfo objekt
            new KontaktInfo{KontaktInfoID=1, Navn="Ola", Telefonnummer="47474747", Epost="ola@mail.com", MailØnsket=true, Samtykke=true, BrukerID=1},

            };
                // Legger til data fra hvert objekt
                kontaktinfo.ForEach(k => context.KontaktInfo.Add(k));
                // Lagrer endringer
                context.SaveChanges();


                // ---------------------------------------------------------------//
                // Setter liste med kvitteringer
                var kvitteringer = new List<Kvittering>
            {
                // Fyller et nytt kvitteringsobjekt
                new Kvittering{KvitteringID=1, KvitteringsDato=DateTime.Parse("2012-10-10"), Kommentar="Kommentar til denne saken", Vedlegg="*Ingen vedlegg lagt til", MatrikkelPath="/Resources/Matrikkel/matrikkel.png", OrtoPath="/Resources/OrtoPhoto/orto.png", ByggesakID=1, KontaktInfoID=1},

            };
                // Legger til data fra hvert objekt
                kvitteringer.ForEach(h => context.Kvitteringer.Add(h));
                // Lagrer endringer
                context.SaveChanges();
            } 
            // ---------------------------------------------------------------//
            catch (Exception ex)
            {
                Err = ex.Message;
                throw ex;
            }
            }
    }

}

