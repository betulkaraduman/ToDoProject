using BusinessLayer.Interfaces;
using DataAccessLayer.Concrete.EFCore.Repositories;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public List<Notification> AllEntitys()
        {
            return _notificationDal.AllEntitys();
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification GetEntityById(int Id)
        {
            return _notificationDal.GetEntityById(Id);
        }

        public int GetNotificationCountByUserId(int UserId)
        {
            return _notificationDal.GetNotificationCountByUserId(UserId);
        }

        public List<Notification> GetNotRead(int AppUserId)
        {
          return  _notificationDal.GetNotRead(AppUserId);
        }

        public int GetNotReadCountByUserId(int UserId)
        {
            return _notificationDal.GetNotificationCountByUserId(UserId);
        }

        public void Save(Notification entity)
        {
            _notificationDal.Save(entity);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
