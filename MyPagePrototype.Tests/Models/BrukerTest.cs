using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyPagePrototype.Models;
//using MyPagePrototype.DAL;

namespace MyPagePrototype.Tests.Models
{
    // Test klasse for bruker
    [TestClass]
    public class BrukerTest { 

        // Const for bruker test
        public BrukerTest () {
        Bruker brukerTest = new Bruker  {   BrukerID = 1,
                                            Navn = "Bob",
                                            Passord = "MittPassord",
                                            Telefonnummer = "47453617",
                                            Epost = "minmail@mail.com"  };
        }

        // Test metode for å lage ny bruker
        [TestMethod]
        public void Lag_Ny_Bruker_Test()
        {
            // Arragne
            Bruker brukerTest = new Bruker {};

            // Act
            brukerTest.BrukerID = 1;
            brukerTest.Navn = "Bob";
            brukerTest.Passord = "MittPassord";
            brukerTest.Telefonnummer = "47453617";
            brukerTest.Epost = "minmail@mail.com";

            // Assert
            Assert.AreNotEqual(brukerTest, new BrukerTest());

            
        }
    }
}
