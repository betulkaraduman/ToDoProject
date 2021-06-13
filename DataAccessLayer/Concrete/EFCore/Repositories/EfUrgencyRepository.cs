using DataAccessLayer.Concrete.EFCore.Contexts;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EFCore.Repositories
{
    public class EfUrgencyRepository : EfGenericRepository<Urgency>, IUrgencyDal
    {
      
    }
}
