using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
   public interface IReportDal:IGenericDal<Report>
    {
        Report GetWorkById(int Id);
        int GetReportCountByUserId(int UserId);
        int GetReportCount();
    }
}
