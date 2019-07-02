using InterviewLists.Application.Models.Car;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface ICarService
    {
        void Create(CarCreate model, string userId);
        void Update(CarUpdate model, IEnumerable<Claim> claims);
        void Delete(int id, IEnumerable<Claim> claims);
        CarDto GetById(int id, IEnumerable<Claim> claims);
        IEnumerable<CarDto> GetAll(IEnumerable<Claim> claims);
    }
}
