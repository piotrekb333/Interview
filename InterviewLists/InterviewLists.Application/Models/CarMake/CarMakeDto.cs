using InterviewLists.Application.Interfaces.Mapping;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.MakeCar
{
    public class CarMakeDto : IMapFrom<CarMake>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
