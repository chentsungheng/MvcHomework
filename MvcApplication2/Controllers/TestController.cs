using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View2()
        {
            return View("View2");
        }

        public ActionResult Alter()
        {
            return PartialView("AltView");
        }

        public ContentResult Direct()
        {
            return Content("Test Content");
        }
    }
}