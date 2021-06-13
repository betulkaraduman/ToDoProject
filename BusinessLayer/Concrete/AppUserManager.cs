using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;
        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> AllMembers()
        {
            return _userDal.AllMembers();
        }
        public List<AppUser> AllMembers(out int sumPage, string searchWord, int activePage )
        {
            return _userDal.AllMembers(out sumPage,searchWord, activePage);
        }

        public List<DualHelper> MostWorkFinishedStaff()
        {
            return _userDal.MostWorkFinishedStaff();
        }

        public List<DualHelper> MostWorkNotFinishedStaff()
        {
            return _userDal.MostWorkNotFinishedStaff();
        }
    }
}
