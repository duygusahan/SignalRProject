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

        public List<Product> Get9Products()
        {
            var context=new SignalRContext();
            var First9Products=context.Products.Take(9).ToList();
            return First9Products;
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

        public decimal SmokyBBQBurgerPrice()
        {
           using var context= new SignalRContext();
            var burgerPrice=context.Products.Where(x=>x.ProductName== "Smoky BBQ Burger").Select(y=>y.Price).FirstOrDefault();
            return burgerPrice;
        }

        public decimal TotalDrinkPrice()
        {
            using var context=new SignalRContext();
            var totalDrinkPrice=context.Products.Where(y=>y.Category.CategoryName== "İçecekler").Select(x=>x.Price).Sum();
            return totalDrinkPrice;
        }

        public decimal TotalProductPrice()
        {
            using var context = new SignalRContext();
            var totalProductPrice = context.Products.Select(x => x.Price).Sum();
            return totalProductPrice;
        }

        public decimal TotalSaladPrice()
        {
            using var context=new SignalRContext();
            var totalSaladPrice=context.Products.Where(x=>x.Category.CategoryName== "Salatalar").Select(y=>y.Price).Sum();
            return totalSaladPrice;
        }
    }
}
