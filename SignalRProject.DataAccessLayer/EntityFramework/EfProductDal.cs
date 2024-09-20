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

        public decimal HamburgerPriceAvg()
        {
            using var context=new SignalRContext(); 
            var HamburgerAvg =context.Products.Include(p => p.Category)
           .Where(p => p.Category.CategoryName == "Hamburgerler").Average(p=>p.Price);
            return HamburgerAvg;    
        }

        public int ProductCount()
        {
            using var context=new SignalRContext();
            return context.Products.Count();

        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context=new SignalRContext();
            var productCount = context.Products
           .Include(p => p.Category)
           .Where(p => p.Category.CategoryName == "İçecekler")
           .Count();

            return productCount;
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            var productCount = context.Products
           .Include(p => p.Category)
           .Where(p => p.Category.CategoryName == "Hamburgerler")
           .Count();

            return productCount;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(p => p.Price);
        }

        public string ProductPriceByMax()
        {
            using var context = new SignalRContext();
            var MaxProduct = context.Products.OrderByDescending(p => p.Price) .FirstOrDefault();
            return MaxProduct.ProductName;
        }

        public string ProductPriceByMin()
        {
            using var context= new SignalRContext();
            var MinProduct=context.Products.OrderBy(p => p.Price) .FirstOrDefault();
            return MinProduct.ProductName;
        }
    }
}
