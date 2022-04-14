using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyPagePrototype.Models;

namespace MyPagePrototype.Tests.Models
{
    // Test klasse for melding
    [TestClass]
    public class MeldingTest
    {
        // Const for melding test
        public MeldingTest()
        {
            Melding meldingTest = new Melding { MeldingID = 1,
                                                MeldingDato = DateTime.Parse("2012-10-10"), 
                                                MeldingTittel = "Melding tittel",
                                                MeldingAvsender = "Kristiansand kommune",
                                                MeldingFilPath = "Kristiansand kommune",
                                                BrukerID = 1                                    };
        }

        // Test metode for å lage ny melding
        [TestMethod]
        public void Lag_Ny_Melding_Test()
        {
            // Arrange
            Melding testMelding = new Melding();

            // Act
            testMelding.MeldingID = 1;
            testMelding.MeldingDato = DateTime.Parse("2012-10-10");
            testMelding.MeldingTittel = "Melding tittel";
            testMelding.MeldingAvsender = "Kristiansand kommune";
            testMelding.MeldingFilPath = "Kristiansand kommune";
            testMelding.BrukerID = 1;

            // Assert
            Assert.AreNotEqual(testMelding, new MeldingTest());
        }
    }
}
