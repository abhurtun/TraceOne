using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TraceOne.Web.Models;

namespace TraceOne.Web.Controllers
{
    public class HomeController : Controller,IHomeController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Message = "Index.";
            return View();
        }

        //Action method Suppliers Page
        public ActionResult Suppliers()
        {
            ViewBag.Message = "Suppliers.";
            return View();
        }
    }

}
