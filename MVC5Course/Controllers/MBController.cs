using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    /// <summary>
    /// Model Binding
    /// </summary>
    /// 
    [Authorize]
    [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Video"] = "PPAP";

            return View();
        }
        [萬聖節活動]
        public ActionResult MyForm()
        {
            return View();
        }
        [勇者檢定]
        public ActionResult IamBOSS()
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

        public ActionResult ProductList()
        {
            var products = repo.GetRows(10);

            return View(products);
        }

        [HttpPost]

        
        public ActionResult BatchUpdate(List<MBProductViewModel> products)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in products)
                {
                    Product product = repo.Find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Active = item.Active;
                    product.Stock = item.Stock;
                    product.Price = item.Price;

                }

                repo.UnitOfWork.Commit();

                return RedirectToAction("ProductList");

            }

            return View();
        }
        public ActionResult ERRORPAGE()
        {
            throw new Exception("不給糖就搗蛋!!");
        }



    }

    public class MBProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        public bool IsDeleted { get; set; }
    }
}