using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.ReportDTOs
{
  public  class ReportAddDto
    {
        //[Required(ErrorMessage = "Definition is required")]
        public string Definition { get; set; }
        //[Required(ErrorMessage = "Detail is required")]
        public string Detail { get; set; }
        public int WorkId { get; set; }
        public Work work { get; set; }
    }
}
