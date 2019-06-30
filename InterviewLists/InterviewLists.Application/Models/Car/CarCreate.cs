using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Car
{
    public class CarCreate
    {
        public int CarMakeId { get; set; }
        public int CarModelId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfProduction { get; set; }
        public string Country { get; set; }
    }
}
