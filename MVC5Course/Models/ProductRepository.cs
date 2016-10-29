using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public override void Delete(Product product)
        {
            product.IsDeleted = true;
        }

        public override IQueryable<Product> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        internal Product Find(int id)
        {
            return this.All().Where(x => x.ProductId == id).FirstOrDefault();
        }

        internal IQueryable<Product> GetRows(int rows)
        {
            return this.All().OrderByDescending(x => x.ProductId).Take(rows);
        }
    }

    public  interface IProductRepository : IRepository<Product>
	{

	}
}