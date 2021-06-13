using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Areas.Admin.Models
{
    public class ReportAddViewModel
    {
        [Required(ErrorMessage ="Definition is required")]
        public string Definition { get; set; }
        [Required(ErrorMessage = "Detail is required")]
        public string Detail { get; set; }
        public int WorkId { get; set; }
        public Work work { get; set; }
    }
}
