﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Areas.Admin.Models
{
    public class WorkListAllViewModel
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
