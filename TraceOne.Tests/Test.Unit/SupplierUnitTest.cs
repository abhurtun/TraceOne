using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

using Moq;
using TraceOne.Web.Controllers;
using TraceOne.Web.Models;

namespace TraceOne.Tests.Test.Unit
{
    [TestClass]
    public class SupplierUnitTest
    {
        [TestMethod]
        public void TestSupplierControllerView()
        {
            var controller = new HomeController();
            var result = controller.Suppliers() as ViewResult;

            // Test we're using the default view name
            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void TestIndexHasListOfSuppliers()
        {
            var mockSupplierRepository = new Mock<ISupplierRepository>();


            List<Supplier> mockSupplier = new List<Supplier>();
            mockSupplier.Add(new Supplier { Name = "Sausage Supplier", Id = 1, Address = "1 Sausage Street" });
            mockSupplier.Add(new Supplier { Name = "Veg Supplier", Id = 2, Address = "2 Veg Street" });
            mockSupplier.Add(new Supplier { Name = "Milk Supplier", Id = 3, Address = "3 Milk Street" });


            // Setup mock behavior for the GetSuppliers method in our repository
            mockSupplierRepository.Setup(x => x.GetSuppliers()).Returns(mockSupplier);


            // Use the implemented supplier controller
            var controller = new SupplierController();

            var suppliers = (IEnumerable<Supplier>)controller.Get();

            // Test the view model contains a list of fish
            Assert.IsNotNull(suppliers, "The list of suppliers does not exist");
            Assert.IsTrue(suppliers.Count() == mockSupplier.Count);

        }
    }
}
