using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetProductsWithCategory();

        int ProductCount();

        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();

        decimal ProductPriceAvg();

        string ProductPriceByMax();
        string ProductPriceByMin();

        decimal HamburgerPriceAvg();

        List<Product> Get9Products();

        decimal SmokyBBQBurgerPrice();
        
        decimal TotalDrinkPrice();
        decimal TotalSaladPrice();

        decimal TotalProductPrice();

      
       


    }
}
