using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        public List<Product> TGetProductsWithCategory();

        public int TProductCount();

        public int TProductCountByCategoryNameDrink();

        int TProductCountByCategoryNameHamburger();

        public decimal TProductPriceAvg();

        public string TProductPriceByMax();

        public string TProductPriceByMin();

        decimal THamburgerPriceAvg();

        List<Product> TGet9Products();
    }
}
