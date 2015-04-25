using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    // abstract controller不會被執行
    public abstract class BaseController : Controller
    {
        protected ClientRepository repClient = RepositoryHelper.GetClientRepository();
        protected OccupationRepository repOccupation = RepositoryHelper.GetOccupationRepository();

#if DEBUG
        public abstract JsonResult Debug();
#endif
    }
}