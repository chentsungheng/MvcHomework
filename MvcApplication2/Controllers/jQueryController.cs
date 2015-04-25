using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcApplication2.Controllers
{
    public class jQueryController : Controller
    {
        // GET: jQuery
        public JsonResult each()
        {
            return Json("test", JsonRequestBehavior.AllowGet);
        }
    }
}