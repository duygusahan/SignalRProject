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
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal  _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TDelete(int id)
        {
            _moneyCaseDal.Delete(id);
        }

        public MoneyCase TGetById(int id)
        {
            return _moneyCaseDal.GetById(id);
        }

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public void TInsert(MoneyCase entity)
        {
           _moneyCaseDal.Insert(entity);
        }

        public decimal TTotalMoneyCase()
        {
            return _moneyCaseDal.TotalMoneyCase();
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);
        }
    }
}
