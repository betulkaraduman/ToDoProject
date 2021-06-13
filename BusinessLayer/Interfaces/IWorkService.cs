using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IWorkService : IGenericService<Work>
    {
        List<Work> NotFinished();
        List<Work> AllData();
        List<Work> AllData(Expression<Func<Work, bool>> filter);

        int GetNotFinishedWorkCountByUserId(int UserId);
        List<Work> AllDataNotFinished(out int SumPage, int UserId, int ActivePage);
        Work GetByUrgencyId(int Id);

        int GetWorkCountByUserId(int UserId);
        List<Work> GetByUserId(int userId);
        int GetFinishWorkCountByUserId();

        int GetNotAssignWorkCountByUserId();
        Work GetReportById(int Id);
    }
}
