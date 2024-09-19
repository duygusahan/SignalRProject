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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int TCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);    
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);    
        }

        public List<Category> TGetListAll()
        {
           return _categoryDal.GetListAll();
        }

        public void TInsert(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
           _categoryDal.Update(entity);
        }
    }
}
