﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.AppUserDTOs
{
   public class AppUserListDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
