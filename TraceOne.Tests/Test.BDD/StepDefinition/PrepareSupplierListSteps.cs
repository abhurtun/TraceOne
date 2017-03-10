using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

using TraceOne.Web.Controllers;
using TraceOne.Web.Models;

namespace TraceOne.Tests.StepDefinition
{
    [Binding]
    public class PrepareSupplierListSteps
    {
         [Given(@"the following suppliers")]
        public void GivenTheFollowingSuppliers(Table givenSuppliers)
        {
            var repository = new SupplierRepository();
            foreach (var row in givenSuppliers.Rows)
            {
                Supplier s = new Supplier { Name = row["Supplier Name"], Id = Convert.ToInt32(row["Supplier Id"]), Address = row["Supplier Address"] };
                repository.Add(s);
            }
             int actualCount = repository.GetSuppliers().Count();

             var givenNames = givenSuppliers.Rows.Select(r => r["Supplier Name"]);
             var expectedNames = repository.GetSuppliers().Select(s => s.Name);

            Assert.AreEqual(givenSuppliers.RowCount, actualCount, "Supplier lists don't contain expected number of suppliers.");
            Assert.IsTrue(givenNames.Except(expectedNames).Count() == 0, "Supplier lists don't contain expected suppliers.");
        }

    }
}
