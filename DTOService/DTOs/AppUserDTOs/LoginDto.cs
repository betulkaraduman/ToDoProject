using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.AppUserDTOs
{
  public class LoginDto
    {
        //[Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
