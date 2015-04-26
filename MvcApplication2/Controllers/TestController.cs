using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public FileResult File01()
        {
            return File(Server.MapPath("~/Content/MVC_1.png"), "image/png");
        }

        public FileResult File02()
        {
            byte[] file = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/MVC_1.png"));

            return File(file, "image/png");
        }

        public FileResult File03()
        {
            FileStream fileStream = System.IO.File.OpenRead(Server.MapPath("~/Content/MVC_1.png"));

            return File(fileStream, "image/png");
        }

        public FileResult Download()
        {
            FileStream fileStream = System.IO.File.OpenRead(Server.MapPath("~/Content/MVC_1.png"));

            return File(fileStream, "image/png", "Stream.png");
        }

        public FileResult Plain()
        {
            return File(Server.MapPath("~/Content/HtmlPage1.html"), "text/plain");
        }

        private FabricsEntities db = new FabricsEntities();

        public JsonResult Json01()
        {
            // Important!!!
            db.Configuration.LazyLoadingEnabled = false;

            return Json(db.Products.Take(20), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Redirect01()
        {
            return RedirectToAction("Plain");
        }

        public ActionResult Redirect02()
        {
            return RedirectToAction("Plain", new { url = "http://tw.yahoo.com" });
        }

        public ActionResult Redirect03()
        {
            return RedirectToActionPermanent("Plain", new { url = "http://tw.yahoo.com" });
        }

        public HttpNotFoundResult Test404()
        {
            return HttpNotFound("404 Test");
        }

        public ActionResult HttpCode()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Created, "Created test");
        }
    }
}