using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class BindingController : Controller
    {
        // GET: Binding
        public ActionResult Index()
        {
            ViewData["ViewMsg"] = "I am a View Message";
            TempData["TempMsg"] = "I am a Temp Message";

            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            ViewBag.ViewMsg = ViewData["ViewMsg"];
            ViewBag.TempMsg = TempData["TempMsg"];

            return View();
        }

        public ActionResult Model()
        {
            MvcApplication2.Models.FabricsEntities db = new Models.FabricsEntities();

            ViewData.Model = db.Products.Find(5);

            return View();
        }
    }
}