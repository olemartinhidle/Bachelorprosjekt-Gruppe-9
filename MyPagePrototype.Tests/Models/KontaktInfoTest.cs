using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyPagePrototype.Models;

namespace MyPagePrototype.Tests.Models
{
    // Test klasse for kontaktinfo
    [TestClass]
    public class KontaktInfoTest
    {
        // Const for kontaktinfo test
        public KontaktInfoTest()
        {
            KontaktInfo kontaktInfoTest = new KontaktInfo { KontaktInfoID = 1,
                                                            Navn = "Bob",
                                                            Telefonnummer = "47353412",
                                                            Epost = "minmail@hotmail.com",
                                                            MailØnsket = true,
                                                            Samtykke = true,
                                                            BrukerID = 1};
        }

        // Test metode for å lage ny kontaktinfo
        [TestMethod]
        public void Lag_Ny_KontaktInfo_Test()
        {
            // Arrange
            KontaktInfo testKontaktInfo = new KontaktInfo();

            // Act
            testKontaktInfo.KontaktInfoID = 1;
            testKontaktInfo.Navn = "Bob";
            testKontaktInfo.Telefonnummer = "47353412";
            testKontaktInfo.Epost = "minmail@hotmail.com";
            testKontaktInfo.MailØnsket = true;
            testKontaktInfo.Samtykke = true;
            testKontaktInfo.BrukerID = 1;

            // Assert
            Assert.AreNotEqual(testKontaktInfo, new KontaktInfoTest());
        }
    }
}
