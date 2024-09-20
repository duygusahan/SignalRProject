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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context= new SignalRContext();
            var ActiveOrder = context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
            return ActiveOrder;
        }

        public decimal LastOrderPrice()
        {
           using var context = new SignalRContext();
            var LastPrice = context.Orders.OrderByDescending(x => x.OrderID).Select(y => y.TotalPrice).FirstOrDefault();
            return LastPrice;
        }

        public int PassiveOrderCount()
        {
           using var context = new SignalRContext();
            var PassiveOrder = context.Orders.Where(x => x.Description == "Hesap Kapatıldı").Count();
            return PassiveOrder;
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            var today = DateTime.Today;
            var totalEarnings = context.Orders
                .Where(o => o.Date.Date == today) 
                .Sum(o => o.TotalPrice); 

            return totalEarnings;
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
