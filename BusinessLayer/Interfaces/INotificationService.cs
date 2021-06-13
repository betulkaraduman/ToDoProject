using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {

        List<Notification> GetNotRead(int AppUserId);

        int GetNotificationCountByUserId(int UserId);
        int GetNotReadCountByUserId(int UserId);



    }
}
