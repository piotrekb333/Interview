using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Domain.Entities
{
    public class Car : BaseEntity
    {
        public int CarMakeId { get; set; }
        public int CarModelId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfProduction { get; set; }
        public string Country { get; set; }
        public CarMake CarMake { get; set; }
        public CarModel CarModel { get; set; }
        public string UserId { get; set; }

    }
}
