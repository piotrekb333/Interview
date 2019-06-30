using InterviewLists.Application.Models.Trip;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface ITripService
    {
        void Create(TripCreate model);
        void Update(TripUpdate model);
        void Delete(int id);
        TripDto GetById(int id);
        IEnumerable<TripDto> GetAll();
    }
}
