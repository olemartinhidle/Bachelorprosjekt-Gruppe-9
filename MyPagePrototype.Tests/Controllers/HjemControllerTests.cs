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
    // Test klasse for hjem kontrolleren
    [TestClass()]
    public class HjemControllerTests
    {
        // Test av index 
        [TestMethod()]
        public void IndexTest()
        {

            // Arrange 
            HjemController hjemcontroller = new HjemController();

            // Act
            ViewResult result = hjemcontroller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);


        }
        // Test av logginn
        [TestMethod()]
        public void LoggInnTest()
        {

            // Arrange 
            HjemController hjemcontroller = new HjemController();

            // Act
            ActionResult result = hjemcontroller.LoggInn() as ActionResult;

            // Assert
            Assert.IsNotNull(result);


        }

        // Test av logg ut
        [TestMethod()]
        public void LoggUtTest()
        {

            // Arrange 
            HjemController hjemcontroller = new HjemController();

            // Act
            ActionResult result = hjemcontroller.LoggUt() as ActionResult;

            // Assert
            Assert.IsNotNull(result);


        }

        // Test av placeholder
        [TestMethod()]
        public void PlaceholderTest()
        {

            // Arrange
            HjemController hjemcontroller = new HjemController();

            // Act
            ViewResult result = hjemcontroller.Placeholder() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}