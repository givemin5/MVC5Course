using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();

            var products = db.Product.Where(x => x.ProductName.Contains("White"));

            return View(products);
        }

        public ActionResult Create()
        {
            var db = new FabricsEntities();

            var product = new Product { ProductName = "White Cat", Active = false, Price = 500, Stock = 1 };

            db.Product.Add(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db = new FabricsEntities();

            var product = db.Product.Where(x => x.ProductId == id).FirstOrDefault();

            if (product != null)
                db.Product.Remove(product);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var db = new FabricsEntities();

            var product = db.Product.Where(x => x.ProductId == id).FirstOrDefault();

            return View(product);
        }
    }
}