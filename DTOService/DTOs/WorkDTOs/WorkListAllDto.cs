using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.WorkDTOs
{
   public class WorkListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public AppUser appUser { get; set; }
        public Urgency urgency { get; set; }
        public List<Report> reports { get; set; }
    }
}
