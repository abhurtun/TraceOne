using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceOne.Web.Models
{
    public class SupplierRepository : ISupplierRepository
    {
        //create dictionary with key value pair
        private Dictionary<Int32,Supplier> suppliers = new Dictionary<Int32,Supplier>();


        public SupplierRepository()
        {
            // Add suppliers
            Add(new Supplier { Name = "Sausage Supplier", Id=1, Address = "1 Sausage Street" });
            Add(new Supplier { Name = "Veg Supplier", Id = 2, Address = "2 Veg Street" });
            Add(new Supplier { Name = "Milk Supplier", Id = 3, Address = "3 Milk Street" });
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return suppliers.Values;
        }

        public void Add(Supplier supplier)
        {
            if (supplier== null)
            {
                throw new ArgumentNullException("no suppliers to add");
            }

            //add or replace to avoid duplicates
            suppliers[supplier.Id] = supplier;

            //return supplier;
        }

    }
}