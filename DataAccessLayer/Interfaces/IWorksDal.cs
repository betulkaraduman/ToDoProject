using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Interfaces
{
    public interface IWorksDal:IGenericDal<Work>
    {
        List<Work> NotFinished();

        List<Work> AllData();
        List<Work> AllData(Expression<Func<Work,bool>> filter);
        List<Work> AllDataNotFinished(out int SumPage,int UserId, int ActivePage);
        Work GetByUrgencyId(int Id);

        List<Work> GetByUserId(int userId);
        int GetWorkCountByUserId(int UserId);
        int GetNotAssignWorkCountByUserId();
        int GetFinishWorkCountByUserId();
        int GetNotFinishedWorkCountByUserId(int UserId);
        Work GetReportById(int Id);
    }
}
