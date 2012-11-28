using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStackShared.Controllers.Attributes;

namespace ServiceStackShared.Controllers
{
    [UserAction]
    public class HomeController : AppControllerBase
    {
        public ActionResult Index()
        {
            UserSession.HelloCount++;
            ViewBag.Message = "Hello! (" + UserSession.HelloCount + " times)";

            return View();
        }

    }
}
