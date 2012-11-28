using System.Web.Mvc;
using System.Linq;
using System.Web.Routing;
using System.Diagnostics;

namespace ServiceStackShared.Controllers.Attributes
{
    public class UserActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = (AppControllerBase)filterContext.Controller;
            var session = controller.GetUserSession;

            session.CustomProperty = "This is a test";
            // also set other values as needed - eg to log a user action such as page view, subscribe, whatever";

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = (AppControllerBase)filterContext.Controller;
            controller.SaveSession();

            base.OnActionExecuted(filterContext);
        }



    }
}