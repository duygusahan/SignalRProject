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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationsByFalse()
        {
            using var context = new SignalRContext();
            var value=context.Notifications.Where(x=>x.Status==false).ToList();
            return value;
        }

        public int NotificationCountByStatusFalse()
        {
           using var context = new SignalRContext();    
        var value=context.Notifications.Where(x=>x.Status==false).Count();
            return value;
        }

        public void NotificationStatusChangeToFalse(int id)
        {
           using var context=new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
    }
}
