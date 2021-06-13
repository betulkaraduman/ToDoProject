using EntityLayer.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
   public class AppUser:IdentityUser<int>,ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "user.png";

        public List<Work> Works { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
