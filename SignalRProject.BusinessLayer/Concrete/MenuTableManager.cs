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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void TDelete(int id)
        {
           _menuTableDal.Delete(id);
        }

        public MenuTable TGetById(int id)
        {
          return _menuTableDal.GetById(id);
        }

        public List<MenuTable> TGetListAll()
        {
            return _menuTableDal.GetListAll();
        }

        public void TInsert(MenuTable entity)
        {
            _menuTableDal.Insert(entity);
        }

        public int TMenuTableCount()
        {
           return _menuTableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
           _menuTableDal.Update(entity);
        }
    }
}
