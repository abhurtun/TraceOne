using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TraceOne.Web.Controllers;
using TraceOne.Web.Models;

namespace TraceOne.Tests.StepDefinition
{
    [Binding]
    public class SupplierSearchSteps
    {
        private IEnumerable<Supplier> suppliers;

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            var controller = new SupplierController();
            suppliers = controller.Get();
        }
        
        [When(@"I search for suppliers")]
        public void WhenISearchForSuppliers()
        {
            var controller = new SupplierController();
            suppliers = controller.Get();
        }

        [Then(@"the result should be a list of suppliers on the screen contain only: (.*)")]
        public void ThenTheResultShouldBeAListOfSuppliersOnTheScreen(string expectedNameList)
        {
            var expectedNames = expectedNameList.Split(',').Select(t => t.Trim().Trim('\''));

            Assert.IsTrue(_matchWithNames(suppliers, expectedNames),"The found books do not match the expected books. Books found: '{0}' ",
                            String.Join<string>(",", suppliers.Select(s => s.Name)));
        }
        
        [Then(@"the list of found suppliers should be:")]
        public void ThenTheListOfFoundSuppliersShouldBe(Table expectedSuppliers)
        {

            var expectedNames = expectedSuppliers.Rows.Select(r => r["Supplier Name"]);

            Assert.IsTrue(_matchInOrderWithNames(suppliers, expectedNames), "The found books do not match the expected books. Books found: '{0}' ",
                            String.Join<String>(",", suppliers.Select(s => s.Name)));
        }

        private static bool _matchWithNames(IEnumerable<Supplier> suppliers, IEnumerable<string> names)
        {
            return names.Count() == suppliers.Count() &&
                   names.Except(suppliers.Select(s => s.Name)).Count() == 0;
        }

        private static bool _matchInOrderWithNames(IEnumerable<Supplier> suppliers, IEnumerable<string> names)
        {
            return names.SequenceEqual(suppliers.Select(s => s.Name));
        }
    }
}
