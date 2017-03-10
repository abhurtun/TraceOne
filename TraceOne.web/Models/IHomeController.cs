using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TraceOne.Web.Models
{
    public interface IHomeController
    {
        ActionResult Index();

        ActionResult Suppliers();
    }
}