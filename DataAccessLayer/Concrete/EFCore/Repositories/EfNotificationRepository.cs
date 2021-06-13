using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.EFCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public int GetNotificationCountByUserId(int UserId)
        {
            using var context = new TodoContext();
            return context.notification.Where(I => I.AppUserId == UserId && !I.State).Count();  
        }

        public List<Notification> GetNotRead(int AppUserId)
        {
            using (var context = new TodoContext())
            {
                return context.notification.Where(I => I.AppUserId == AppUserId && !I.State).ToList();
            }
        }

        public int GetNotReadCountByUserId(int UserId)
        {
            using (var context = new TodoContext())
            {
                return context.notification.Where(I => I.AppUserId == UserId && !I.State).Count();
            }
        }
    }
}
