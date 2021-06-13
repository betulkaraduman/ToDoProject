using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {

        Report GetWorkById(int Id);
        int GetReportCountByUserId(int UserId);
        int GetReportCount();
    }
}
