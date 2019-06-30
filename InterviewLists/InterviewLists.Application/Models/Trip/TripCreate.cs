using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Trip
{
    public class TripCreate
    {
        public decimal Price { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Country { get; set; }
    }
}
