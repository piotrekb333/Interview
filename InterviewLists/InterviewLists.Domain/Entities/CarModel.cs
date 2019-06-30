using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Domain.Entities
{
    public class CarModel : BaseEntity
    {
        public int CarMakeId { get; set; }
        public string Title { get; set; }

        public CarMake CarMake { get; set; }
        public ICollection<Car> Cars { get; private set; }

    }
}
