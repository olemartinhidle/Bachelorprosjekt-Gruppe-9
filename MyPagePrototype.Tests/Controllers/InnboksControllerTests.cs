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
    // Test klasse for innboks kontroller
    [TestClass()]
    public class InnboksControllerTests
    {
        // Indeks test
        [TestMethod()]
        public void IndexTest()
        {

            // Arrange
            InnboksController innboksController = new InnboksController();

            // Act
            ViewResult result = innboksController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
        // Test av slett melding funksjonen
        [TestMethod()]
        public void SlettTest()
        {

            // Arrange
            InnboksController innboksController = new InnboksController();
            int mid = 1;

            // Act
            ActionResult result = innboksController.Slett(mid) as ActionResult;

            // Assert
            Assert.IsNotNull(result);

        }

    }
}