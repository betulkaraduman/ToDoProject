using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Urgency:ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public List<Work> works { get; set; }
    }
}
