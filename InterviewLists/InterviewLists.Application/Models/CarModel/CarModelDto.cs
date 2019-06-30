using InterviewLists.Application.Interfaces.Mapping;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.ModelCar
{
    public class CarModelDto : IMapFrom<CarModel>
    {
        public int Id { get; set; }
        public int CarMakeId { get; set; }
        public string Title { get; set; }
    }
}
