using Microsoft.EntityFrameworkCore;
using SignalRProject.DataAccessLayer.Abstract;
using SignalRProject.DataAccessLayer.Context;
using SignalRProject.DataAccessLayer.Repositories;
using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategory()
        {
           var context = new SignalRContext();
            var value=context.Products.Include(x=>x.Category).Select(y=>new Product
            {
                ProductName = y.ProductName,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                Status = y.Status,
                ProductId = y.ProductId,
                Category = new Category { CategoryName=y.Category.CategoryName}
            }).ToList();
            return value;
        }

        public int ProductCount()
        {
            using var context=new SignalRContext();
            return context.Products.Count();

        }
    }
}
