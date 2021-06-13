using EntityLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Report:ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Detail { get; set; }
        public int WorkId { get; set; }
        public Work work { get; set; }
    }
}
