using BusinessLayer.Interfaces;
using DataAccessLayer.Concrete.EFCore.Repositories;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class WorkManager : IWorkService
    {
        private IWorksDal _workDal;
        public WorkManager(IWorksDal workDal)
        {
            _workDal = workDal;
            //_workRepo = new EfWorksRepository();
        }

        public List<Work> AllData()
        {
            return _workDal.AllData();
        }

        public List<Work> AllData(Expression<Func<Work, bool>> filter)
        {
            return _workDal.AllData(filter);
        }

        public List<Work> AllDataNotFinished(out int SumPage, int UserId, int ActivePage)
        {
            return _workDal.AllDataNotFinished(out SumPage,UserId,ActivePage);
        }

        public List<Work> AllEntitys()
        {
            return _workDal.AllEntitys();
        }

        public void Delete(Work entity)
        {
            _workDal.Delete(entity);
        }

        public Work GetByUrgencyId(int Id)
        {
            return _workDal.GetByUrgencyId(Id);
        }

        public List<Work> GetByUserId(int userId)
        {
            return _workDal.GetByUserId(userId);
        }

        public Work GetEntityById(int Id)
        {
            return _workDal.GetEntityById(Id);
        }

        public int GetFinishWorkCountByUserId()
        {
            return _workDal.GetFinishWorkCountByUserId();
        }

        public int GetNotAssignWorkCountByUserId()
        {
            return _workDal.GetNotAssignWorkCountByUserId();
        }

        public int GetNotFinishedWorkCountByUserId(int UserId)
        {
            return _workDal.GetNotFinishedWorkCountByUserId(UserId);
        }

        public Work GetReportById(int Id)
        {
            return _workDal.GetReportById(Id);
        }

        public int GetWorkCountByUserId(int UserId)
        {
            return _workDal.GetWorkCountByUserId(UserId);
        }

        public List<Work> NotFinished()
        {
            return _workDal.NotFinished();
        }

        public void Save(Work entity)
        {
            _workDal.Save(entity);
        }

        public void Update(Work entity)
        {
            _workDal.Update(entity);
        }
    }
}
