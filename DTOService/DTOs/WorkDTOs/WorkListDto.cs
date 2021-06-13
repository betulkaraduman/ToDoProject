using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOService.DTOs.WorkDTOs
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public bool State { get; set; }
        public int UrgencyId { get; set; }
        public Urgency urgency { get; set; }
    }
}
