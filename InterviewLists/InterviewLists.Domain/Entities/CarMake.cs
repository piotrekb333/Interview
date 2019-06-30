using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Domain.Entities
{
    public class CarMake : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<Car> Cars { get; private set; }
        public ICollection<CarModel> CarModels { get; private set; }

    }
}
