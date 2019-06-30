using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Domain.Entities
{
    public class Trip : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Country { get; set; }
    }
}
