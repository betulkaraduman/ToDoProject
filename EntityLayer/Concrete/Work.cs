using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Work:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public bool State { get; set; }
        public int? AppUserId { get; set; }
        public AppUser appUser { get; set; }
        public int UrgencyId { get; set; }
        public Urgency urgency { get; set; }

        public List<Report> reports { get; set; }
    }
}
