using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyPagePrototype.DAL;




namespace MyPagePrototype.Tests.DAL
{
    // Test klasse for minside init
    [TestClass]
    public class MinSideInitializerTest
    {
        // Eventuell const
        public MinSideInitializerTest()
        {
            // Eventuell const
        }

        // Test metode for å starte init
        [TestMethod]
        public void Start_Med_Data()
        {
            // Arrange
            MinSideInitializer initTest = new MinSideInitializer();
            MinSideContext minSideContext = new MinSideContext();
            // Act 
            initTest.InitializeDatabase(minSideContext);

            // Assert
            Assert.IsNotNull(initTest);
        }
    }
}
