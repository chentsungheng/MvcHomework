using MvcApplication2.Models;
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

        public ActionResult Base()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Base(string UserName, string Password)
        {
            return Content(string.Format("Base type ---> Username is {0}, Password is {1}", UserName, Password));
        }

        public ActionResult Form()
        {
            return View("Base");
        }

        [HttpPost]
        public ActionResult Form(FormCollection PostForm)
        {
            return Content(string.Format("Form type ---> Username is {0}, Password is {1}", PostForm["UserName"], PostForm["Password"]));
        }

        public ActionResult typed()
        {
            return View("Base");
        }

        [HttpPost]
        public ActionResult typed(DemoViewModel ViewModel)
        {
            return Content(string.Format("Typed ---> Username is {0}, Password is {1}", ViewModel.UserName, ViewModel.Password));
        }

        public ActionResult DoubleBinding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoubleBinding(DemoViewModel Item1, DemoViewModel Item2)
        {
            return Content(string.Format("Double ---> Username1 is {0}, Password1 is {1}, Username2 is {2}, Password2 is {3}", Item1.UserName, Item1.Password, Item2.UserName, Item2.Password));
        }
    }
}