using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

using Moq;
using TraceOne.Web.Models;
using TraceOne.Web.Controllers;

namespace TraceOne.Tests
{
    [TestClass]
    public class HomeUnitTest
    {
        [TestMethod]
        public void TestHomeControllerViewIndex()
        {
            // Create a new mock controller based on the IHomeController interfce
            //var controller = new Mock<IHomeController>();

            // Configure the interface's Index() method to return a ViewResult
            //controller.Setup(c => c.Index()).Returns(new ViewResult());

            // Call the mocked Index() method - note access is via controller.Object
            //var result = controller.Object.Index() as ViewResult;

            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            // Test we're using the default view name
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void TestHomeControllerViewSuppliers()
        {
            
            // Create a new mock controller based on the IHomeController interfce
            //var controller = new Mock<IHomeController>();

            // Configure the interface's Index() method to return a ViewResult
            //controller.Setup(c => c.Suppliers()).Returns(new ViewResult());

            // Call the mocked Index() method - note access is via controller.Object
            //var result = controller.Object.Suppliers() as ViewResult;

            var controller = new HomeController();
            var result = controller.Suppliers() as ViewResult;

            // Test we're using the default view name
            Assert.AreEqual("", result.ViewName);
        }
    }
}
