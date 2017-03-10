using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TraceOne.Web.Controllers;
using TraceOne.Web.Models;

namespace TraceOne.Tests
{
    [Binding]
    public class HomeSteps
    {
        private ActionResult actionResult;

        [When(@"Retailer user launches the home screen")]
        public void WhenRetailerUserLaunchesTheHomeScreen()
        {
            var controller = new HomeController();
            actionResult = controller.Suppliers();
        }
        
        [Then(@"the home screen should show no suppliers")]
        public void ThenTheHomeScreenShouldShowNoSuppliers()
        {
            var viewResult = actionResult as ViewResult;
            var actual = viewResult.ViewBag.Message;
            var expected = "Suppliers.";

            Assert.IsNotNull(viewResult);
            Assert.AreEqual(expected, actual);
        }
    }
}
