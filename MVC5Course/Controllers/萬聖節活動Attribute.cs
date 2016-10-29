using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class 萬聖節活動Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var value = new Random().Next(0, 10);
            if (value % 2 ==1)
                filterContext.Controller.TempData["活動訊息"] = "搗蛋沒糖吃";
            else
                filterContext.Controller.TempData["活動訊息"] = "沒有中獎";
        }
    }
}