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
    // Test klasse for profil kontrolleren
    [TestClass()]
    public class ProfilControllerTests
    {
        // Test metode for indeks
        [TestMethod()]
        public void IndexTest()
        {

            // Arrange
            ProfilController profilController = new ProfilController();

            // Act
            ViewResult result = profilController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}