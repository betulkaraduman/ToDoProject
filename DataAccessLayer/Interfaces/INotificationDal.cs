using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
   public interface INotificationDal : IGenericDal<Notification>
    {
        int GetNotificationCountByUserId(int UserId);
        int GetNotReadCountByUserId(int UserId);
        List<Notification> GetNotRead(int AppUserId);

    }
}
