using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPagePrototype.Controllers;
using MyPagePrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers.Tests
{
    // Test klasse for byggesaker kontrolleren
    [TestClass()]
    public class MineByggesakerControllerTests
    {
        // Test metode for indeks
        [TestMethod()]
        public void IndexTest()
        {

            // Arrange
            MineByggesakerController mineByggesakerController = new MineByggesakerController();

            // Act
            ViewResult result = mineByggesakerController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // Test metode for å finne frem skjema for ny byggesak
        [TestMethod()]
        public void RegistrerTestView()
        {

            // Arrange
            MineByggesakerController mineByggesakerController = new MineByggesakerController();

            // Act
            ViewResult result = mineByggesakerController.Registrer() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // Test metode for registrering av ny byggesak
        [TestMethod()]
        public void RegistrerTestRegistrer()
        {

            // Arrange
            MineByggesakerController mineByggesakerController = new MineByggesakerController();
            Byggesak byggesak = new Byggesak    {   ByggesakID = 1,
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
                                                    BrukerID = 1                                };

            // Act
            ViewResult result = mineByggesakerController.Registrer(byggesak) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        // Test metode for fjerning av en kvittering som ikke er ferdigstilt
        [TestMethod()]
        public void FjernEndringTest()
        {

            // Arrange
            MineByggesakerController mineByggesakerController = new MineByggesakerController();

            // Act
            ViewResult result = mineByggesakerController.FjernEndring() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}