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

            var product = db.Product.Find(id);

            if (product != null)
            {
                db.OrderLine.RemoveRange(product.OrderLine);
                db.Product.Remove(product);
            }
                

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var db = new FabricsEntities();

            var product = db.Product.Find(id);

            return View(product);
        }

        public ActionResult Update(int id)
        {
            var db = new FabricsEntities();
            var product = db.Product.Find(id);

            if (product != null)
                product.ProductName += "!";

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Add20Percent()
        {
            var db = new FabricsEntities();
            var products = db.Product.Where(x => x.ProductName.Contains("White"));

            foreach (var product in products) {
                if (product.Price.HasValue)
                {
                    product.Price = product.Price.Value * 1.2m;
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}