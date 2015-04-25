using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcApplication2.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{

	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}