using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    /// <summary>
    /// Model Binding
    /// </summary>
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Video"] = "PPAP";

            return View();
        }
        public ActionResult MyForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyForm(Product product)
        {
            if (ModelState.IsValid) {
                TempData["Message"] = "儲存成功";
                return RedirectToAction("MyFormResult");
            }

            return View();
        }
        public ActionResult MyFormResult()
        {
            return View();
        }

    }
}