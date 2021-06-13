using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Areas.Admin.Models
{
    public class UrgencyAddViewModel
    {
        [Required(ErrorMessage = "Definition cannot be empty")]
        public string Definition
        {
            get; set;
        }
    }
}
