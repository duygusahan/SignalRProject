using SignalRProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DataAccessLayer.Abstract
{
    public interface INotificationDal:IGenericDal<Notification>
    {
        public int NotificationCountByStatusFalse();

        List<Notification> GetAllNotificationsByFalse();

        void NotificationStatusChangeToTrue(int id);
        void NotificationStatusChangeToFalse(int id);
    }
}
