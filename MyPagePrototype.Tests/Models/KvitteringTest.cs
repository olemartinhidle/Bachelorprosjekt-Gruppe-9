using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyPagePrototype.Models;

namespace MyPagePrototype.Tests.Models
{
    // Test klasse for kvittering
    [TestClass]
    public class KvitteringTest
    {
        // Const for kvittering test
        public KvitteringTest()
        {
           Kvittering kvitteringTest = new Kvittering { KvitteringID = 1,
                                                        KvitteringsDato = DateTime.Parse("2012-10-10"),
                                                        Kommentar = "Min kommentar",
                                                        Vedlegg = "Ingen filer lagt ved",
                                                        MatrikkelPath = "path/til/matrikkel",
                                                        OrtoPath = "path/til/orto",
                                                        ByggesakID = 1,
                                                        KontaktInfoID = 1                               };
        }

        // Test metode for å lage ny kvittering
        [TestMethod]
        public void Lag_Ny_Kvittering_Test()
        {
            // Arrange
            Kvittering testKvittering = new Kvittering();

            // Act
            testKvittering.KvitteringID = 1;
            testKvittering.KvitteringsDato = DateTime.Parse("2012-10-10");
            testKvittering.Kommentar = "Min kommentar";
            testKvittering.Vedlegg = "Ingen filer lagt ved";
            testKvittering.MatrikkelPath = "path/til/matrikkel";
            testKvittering.OrtoPath = "path/til/orto";
            testKvittering.ByggesakID = 1;
            testKvittering.KontaktInfoID = 1;

            // Assert
            Assert.AreNotEqual(testKvittering, new KvitteringTest());
        }
    }
}
