using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cat()
        {
            var path = Server.MapPath("~/Uploads/Cat.jpg");
            
            return File(path, "image/jpeg");
        }
        public ActionResult Cat2Download()
        {
            var path = Server.MapPath("~/Uploads/Cat.jpg");

            return File(path, "image/jpeg","cat.jpg");
        }
    }
}