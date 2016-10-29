using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class 勇者檢定Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Controller.TempData["系統資訊"] = "你還沒準備好";
                filterContext.Result = new RedirectResult("/");
            }
                
        }
    }
}