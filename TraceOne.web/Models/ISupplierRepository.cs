using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraceOne.Web.Models
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        void Add(Supplier item);

    }
}