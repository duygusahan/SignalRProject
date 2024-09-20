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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
        }

        public decimal TotalMoneyCase()
        {
            using var context=new SignalRContext();
            var TotalAmount=context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
            return TotalAmount;
        }
    }
}
