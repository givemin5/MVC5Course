using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        internal Product Find(int id)
        {
            return this.All().Where(x => x.ProductId == id).FirstOrDefault();
        }
    }

    public  interface IProductRepository : IRepository<Product>
	{

	}
}