using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TraceOne.Web.Models;

namespace TraceOne.Web.Controllers
{
    public class SupplierController : ApiController
    {
        //create a supplier repository
        static readonly ISupplierRepository repository = new SupplierRepository();


        // GET api/suppliers
        public IEnumerable<Supplier> Get()
        {
            var sup = repository.GetSuppliers().OrderBy((s) => s.Name);
            return sup.ToList();
        }

        // GET api/suppliers/5
        public Supplier Get(int id)
        {
            return repository.GetSuppliers().Where((s) => s.Id == id).FirstOrDefault();
        }

        // POST api/suppliers
        public void Post([FromBody]string value)
        {
        }

        // PUT api/suppliers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/suppliers/5
        public void Delete(int id)
        {
        }
    }
}
