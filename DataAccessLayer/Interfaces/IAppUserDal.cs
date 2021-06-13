using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        List<AppUser> AllMembers();
        List<AppUser> AllMembers(out int sumPage, string searchWord, int activePage = 1);
        List<DualHelper> MostWorkFinishedStaff();
        List<DualHelper> MostWorkNotFinishedStaff();
     }
}
