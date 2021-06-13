using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.UrgencyDTOs
{
   public class UrgencyUpdateDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Definition is reuqired")]
        public string Definition { get; set; }
    }
}
