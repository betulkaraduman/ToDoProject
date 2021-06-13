using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Areas.Admin.Models
{
    public class UserWorksListViewModel
    {
        public AppUserListViewModel appUser { get; set; }
        public WorkListViewModel work { get; set; }
    }
}
