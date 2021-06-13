using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
