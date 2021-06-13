using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Areas.Admin.Models
{
    public class WorkAddViewModel
    {

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,int.MaxValue,ErrorMessage="Please Select an Urgency State")]
        public int UrgencyId { get; set; }
        public SelectList Urgencies { get; set; }

    }
}
