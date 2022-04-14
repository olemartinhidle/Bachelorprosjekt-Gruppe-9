using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPagePrototype.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyPagePrototype.Controllers.Tests
{
    // Test klasse for kvittering kontrolleren
    [TestClass()]
    public class KvitteringControllerTests
    {
        // Test metode for generering av kvittering
        [TestMethod()]
        public void GenKvitteringTest()
        {

            // Arrange
            KvitteringController kvitteringController = new KvitteringController();

            // Act
            ActionResult result = kvitteringController.GenKvittering() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // Test metode for å finne frem en kvittering
        [TestMethod()]
        public void DetaljerTest()
        {

            // Arrange
            KvitteringController kvitteringController = new KvitteringController();
            int id = 1;
            // Act
            ViewResult result = kvitteringController.Detaljer(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}