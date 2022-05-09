using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPagePrototype.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPagePrototype.Models;

namespace MyPagePrototype.Test.DAL
{
    // Test klasse for test av MinSideContext
    [TestClass]
    public class MinSideContextTests
    {
        // Const for denne testen
        public MinSideContextTests() {
            MinSideContext kontekst = new MinSideContext();
        }

        // Test metode for å legge til data i denne contexten
        [TestMethod]
        public void Legg_Til_Data_Test()
        {
            // Arrange 
            MinSideContext kontekstsTest = new MinSideContext();
            KontaktInfo kontakt = new KontaktInfo
            {
                KontaktInfoID = 1,
                Navn = "Bob",
                Telefonnummer = "47353412",
                Epost = "minmail@hotmail.com",
                MailØnsket = true,
                Samtykke = true,
                BrukerID = 1
            };
            Kvittering kvittering = new Kvittering
            {
                KvitteringID = 1,
                KvitteringsDato = DateTime.Parse("2012-10-10"),
                Kommentar = "Min kommentar",
                Vedlegg = "Ingen filer lagt ved",
                MatrikkelPath = "path/til/matrikkel",
                OrtoPath = "path/til/orto",
                ByggesakID = 1,
                KontaktInfoID = 1
            };
            Bruker bruker = new Bruker
            {
                BrukerID = 1,
                Navn = "Bob",
                Passord = "MittPassord",
                Telefonnummer = "47453617",
                Epost = "minmail@mail.com"
            };
            Byggesak byggesak = new Byggesak
            {
                ByggesakID = 1,
                ByggesakTema = "Tema",
                TypeBygg = "Bolig",
                ByggningsNummer = 345212,
                ByggesakTittel = "Denne tittel",
                ByggesakDato = DateTime.Parse("2012-10-10"),
                ByggesakStatus = "Ubehandlet",
                NæringsGruppe = "Ikke oppgitt",
                NyttAreal = 123,
                NyHøyde = 123,
                KvitteringID = 1,
                BrukerID = 1
            };

            // Act 
            kontekstsTest.Brukere.Add(bruker);
            kontekstsTest.Byggesaker.Add(byggesak);
            kontekstsTest.KontaktInfo.Add(kontakt);
            kontekstsTest.Kvitteringer.Add(kvittering);
          

            // Assert
            Assert.IsNotNull(kontekstsTest.Brukere);
            Assert.IsNotNull(kontekstsTest.Byggesaker);
            Assert.IsNotNull(kontekstsTest.KontaktInfo);
            Assert.IsNotNull(kontekstsTest.Kvitteringer);
            

        }
    }
}