using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
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
                //db.OrderLine.RemoveRange(product.OrderLine);
                //db.Product.Remove(product);
                product.IsDeleted = true;
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

            var p0 = "%White%";
            var strSQL = "Update Product Set Price = Price*1.2 Where ProductName like @p0";

            db.Database.ExecuteSqlCommand(strSQL, p0);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var vError in entityErrors.ValidationErrors)
                    {
                        throw new DbEntityValidationException(
                            vError.PropertyName + "發生錯誤 : " + vError.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult StoreProduce()
        {
            return View();
        }
        public ActionResult GetViewBySQLQuery()
        {
            var db = new FabricsEntities();

            var Name = "%Mary%";

            var strSQL = @"SELECT
		 c.ClientId,
		 c.FirstName,
		 c.LastName,
		 (SELECT SUM(o.OrderTotal) 
		  FROM [dbo].[Order] o 
		  WHERE o.ClientId = c.ClientId) as OrderTotal
	FROM 
		[dbo].[Client] as c Where FirstName like @p0";

            var vw = db.Database.SqlQuery<vw_ClientContribution>(strSQL, Name);
            return View(vw);
        }

        public ActionResult ClientContribution()
        {
            var db = new FabricsEntities();

            var clientsC = db.vw_ClientContribution.Take(10);

            return View(clientsC);
        }
        public ActionResult QueryStoreProcedure(string keyword)
        {
            return View(db.usp_GetClientContribution(keyword));
        }
    }
}