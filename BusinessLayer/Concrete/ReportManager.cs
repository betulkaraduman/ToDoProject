using BusinessLayer.Interfaces;
using DataAccessLayer.Concrete.EFCore.Repositories;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ReportManager : IReportService
    {
        private IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public List<Report> AllEntitys()
        {
            return _reportDal.AllEntitys();
        }

        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public Report GetEntityById(int Id)
        {
            return _reportDal.GetEntityById(Id);
        }

        public int GetReportCount()
        {
            return _reportDal.GetReportCount();
        }

        public int GetReportCountByUserId(int UserId)
        {
            return _reportDal.GetReportCountByUserId(UserId);
        }

        public Report GetWorkById(int Id)
        {
            return _reportDal.GetWorkById(Id);
        }

        public void Save(Report entity)
        {
            _reportDal.Save(entity);
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }
    }
}
