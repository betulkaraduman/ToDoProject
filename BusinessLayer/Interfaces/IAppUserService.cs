using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> AllMembers();
        public List<AppUser> AllMembers(out int sumPage, string searchWord, int activePage);
        List<DualHelper> MostWorkFinishedStaff();
        List<DualHelper> MostWorkNotFinishedStaff();
    }
}
