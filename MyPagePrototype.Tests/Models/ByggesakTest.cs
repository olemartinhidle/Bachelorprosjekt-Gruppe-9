using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyPagePrototype.Models;

namespace MyPagePrototype.Tests.Models
{
    // Test klasse for byggesak
    [TestClass]
    public class ByggesakTest
    {
        // Const for byggesak test
        public ByggesakTest()
        {
            Byggesak byggesak = new Byggesak { ByggesakID = 1,
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
                                               BrukerID = 1 };
        }

        // Test metode for å lage ny byggesak
        [TestMethod]
        public void Lag_Ny_Byggesak_Test()
        {
            // Arrange
            Byggesak testByggesak = new Byggesak();

            // Act
            testByggesak.ByggesakID = 1;
            testByggesak.ByggesakTema =  "Tema";
            testByggesak.TypeBygg = "Bolig";
            testByggesak.ByggningsNummer = 345212;
            testByggesak.ByggesakTittel = "Denne tittel";
            testByggesak.ByggesakDato = DateTime.Parse("2012-10-10");
            testByggesak.ByggesakStatus = "Ubehandlet";
            testByggesak.NæringsGruppe = "Ikke oppgitt";
            testByggesak.NyttAreal = 123;
            testByggesak.NyHøyde = 123;
            testByggesak.KvitteringID = 1;
            testByggesak.BrukerID = 1;

            // Assert
            Assert.AreNotEqual(testByggesak, new ByggesakTest());
        }
    }
}
