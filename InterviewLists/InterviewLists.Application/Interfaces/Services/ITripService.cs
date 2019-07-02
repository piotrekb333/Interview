using InterviewLists.Application.Models.Trip;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface ITripService
    {
        void Create(TripCreate model, string userId);
        void Update(TripUpdate model, IEnumerable<Claim> claims);
        void Delete(int id, IEnumerable<Claim> claims);
        TripDto GetById(int id, IEnumerable<Claim> claims);
        IEnumerable<TripDto> GetAll(IEnumerable<Claim> claims);
    }
}
