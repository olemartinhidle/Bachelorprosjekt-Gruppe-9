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
    // Test klasse fo kontaktinfokontrolleren
    [TestClass()]
    public class KontaktInfoControllerTests
    {
        // Test metode for view av kontaktinfo skjema
        [TestMethod()]
        public void SendTestView()
        {

            // Arrange
            KontaktInfoController kontaktInfoController = new KontaktInfoController();

            // Act
            ViewResult result = kontaktInfoController.Send() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        // Test metode for å registrere ny kontaktinfo
        [TestMethod()]
        public void SendTestRegister()
        {

            // Arrange
            KontaktInfoController kontaktInfoController = new KontaktInfoController();
            KontaktInfo kontaktinfo = new KontaktInfo   {   KontaktInfoID = 1,
                                                            Navn = "Bob",
                                                            Telefonnummer = "47353412",
                                                            Epost = "minmail@hotmail.com",
                                                            MailØnsket = true,
                                                            Samtykke = true,
                                                            BrukerID = 1                    }; 
            // Act
            ViewResult result = kontaktInfoController.Send(kontaktinfo) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }
    }
}