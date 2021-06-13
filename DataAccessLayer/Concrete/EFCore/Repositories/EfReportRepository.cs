using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EFCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public int GetReportCount()
        {
            using var context = new TodoContext();
            return context.reports.Count();
        }

        public int GetReportCountByUserId(int UserId)
        {
            using var context = new TodoContext();
            var result = context.work.Include(I => I.reports).Where(I => I.AppUserId == UserId);
            return result.SelectMany(I => I.reports).Count();
        }

        public Report GetWorkById(int Id)
        {
            using var context = new TodoContext();
            return context.reports.Include(I => I.work).ThenInclude(I => I.urgency).Where(I => I.Id == Id).FirstOrDefault();
        }
    }
}
