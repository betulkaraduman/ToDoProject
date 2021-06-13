using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.WorkDTOs
{
   public class WorkAddDto
    {
        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Please Select an Urgency State")]
        public int UrgencyId { get; set; }
        //public SelectList Urgencies { get; set; }
    }
}
