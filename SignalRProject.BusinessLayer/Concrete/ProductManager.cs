using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DataAccessLayer.Abstract;
using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

      

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> TGet9Products()
        {
            return _productDal.Get9Products();
        }

        public Product TGetById(int id)
        {
           return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

        public decimal THamburgerPriceAvg()
        {
            return _productDal.HamburgerPriceAvg();
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public int TProductCount()
        {
          return  _productDal.ProductCount();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _productDal.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public string TProductPriceByMax()
        {
            return _productDal.ProductPriceByMax();
        }

        public string TProductPriceByMin()
        {
            return _productDal.ProductPriceByMin();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
