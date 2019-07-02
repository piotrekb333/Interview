using InterviewLists.Application.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Trip
{
    public class TripDto : IMapFrom<Domain.Entities.Trip>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public bool AllowModifications { get; set; } = false;

    }
}
