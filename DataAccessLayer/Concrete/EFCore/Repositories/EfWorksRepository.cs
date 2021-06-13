using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete.EFCore.Repositories
{
    public class EfWorksRepository : EfGenericRepository<Work>, IWorksDal
    {
        public List<Work> AllData()
        {
            using (var context = new TodoContext())
            {
                var works = context.work.Include(I => I.urgency).Where(I => !I.State).Include(I => I.reports).Include(I => I.appUser).OrderByDescending(I => I.CreateTime).ToList();
                return works;
            }
        }

        public List<Work> AllData(Expression<Func<Work, bool>> filter)
        {
            using (var context = new TodoContext())
            {
                var works = context.work.Include(I => I.urgency).Include(I => I.reports).Include(I => I.appUser).Where(filter).OrderByDescending(I => I.CreateTime).ToList();
                return works;
            }
        }

        public List<Work> AllDataNotFinished(out int SumPage, int UserId,int ActivePage=1)
        {
            using (var context = new TodoContext())
            {
                var works = context.work.Include(I => I.urgency).Include(I => I.reports).Include(I => I.appUser).Where(I => I.AppUserId == UserId && I.State).OrderByDescending(I => I.CreateTime);
                SumPage = (int)Math.Ceiling((double)works.Count() / 3);
                return works.Skip((ActivePage - 1) * 3).Take(3).ToList();
            }
        }

        public Work GetByUrgencyId(int Id)
        {
            using (var context = new TodoContext())
            {
                var work = context.work.Include(I => I.urgency).Where(I => I.Id == Id).FirstOrDefault();
                return work;
            }
        }

        public List<Work> GetByUserId(int userId)
        {
            using (var context = new TodoContext())
            {
                return context.work.Where(I => I.AppUserId == userId).ToList();
            }

        }

        public int GetFinishWorkCountByUserId()
        {
            using var context = new TodoContext();
            return context.work.Count(I=>I.State);
        }

        public int GetNotAssignWorkCountByUserId()
        {
            using var context = new TodoContext();
            return context.work.Count(I => I.AppUserId == null && !I.State);
        }

        public int GetNotFinishedWorkCountByUserId(int UserId)
        {
            using var context = new TodoContext();
            return context.work.Where(I => I.AppUserId == UserId && !I.State).Count();
        }

        public Work GetReportById(int Id)
        {
            using(var context =new TodoContext())
            {
               return context.work.Include(I => I.reports).Include(I=>I.appUser).Where(i => i.Id == Id).FirstOrDefault();
            }
        }

        public int GetWorkCountByUserId(int UserId)
        {
            using var context = new TodoContext();
            return context.work.Where(I => I.AppUserId == UserId && I.State).Count();
        }

        public List<Work> NotFinished()
        {
            using (var context = new TodoContext())
            {
                var works = context.work.Include(I => I.urgency).Where(I => !I.State).OrderByDescending(I => I.CreateTime).ToList();
                return works;
            }
        }
    }
}
