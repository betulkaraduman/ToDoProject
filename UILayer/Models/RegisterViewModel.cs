using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username is required")]
        public string  Username { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string  Password { get; set; }
        [Compare("Password",ErrorMessage ="Passwords are not matched")]
        public string  ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string  Email { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string  Surname { get; set; }
    }
}
