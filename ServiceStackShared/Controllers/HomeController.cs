using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceStackShared.Controllers
{
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
