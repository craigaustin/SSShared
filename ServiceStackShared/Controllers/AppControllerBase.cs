using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Mvc;
using ServiceStackShared.App_Start;

namespace ServiceStackShared.Controllers
{
    public class AppControllerBase : ServiceStackController<CustomUserSession> { }
}