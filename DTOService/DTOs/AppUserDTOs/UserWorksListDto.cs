using DTOService.DTOs.WorkDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.AppUserDTOs
{
   public class UserWorksListDto
    {
        public AppUserListDto appUser { get; set; }
        public WorkListDto work { get; set; }
    }
}
