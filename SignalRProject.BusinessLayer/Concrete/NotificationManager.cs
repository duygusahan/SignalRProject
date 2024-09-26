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
    public class NotificationManager : INotificationsService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(int id)
        {
           _notificationDal.Delete(id);
        }

        public List<Notification> TGetAllNotificationsByFalse()
        {
           return _notificationDal.GetAllNotificationsByFalse();
        }

        public Notification TGetById(int id)
        {
           return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll()
        {
           return _notificationDal.GetListAll();
        }

        public void TInsert(Notification entity)
        {
            _notificationDal.Insert(entity);
        }

        public int TNotificationCountByStatusFalse()
        {
            return _notificationDal.NotificationCountByStatusFalse();
        }

        public void TNotificationStatusChangeToFalse(int id)
        {
             _notificationDal.NotificationStatusChangeToFalse(id);
        }

        public void TNotificationStatusChangeToTrue(int id)
        {
            _notificationDal.NotificationStatusChangeToTrue(id);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
