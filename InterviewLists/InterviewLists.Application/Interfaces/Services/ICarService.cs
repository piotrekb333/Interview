using InterviewLists.Application.Models.Car;
using InterviewLists.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface ICarService
    {
        void Create(CarCreate model);
        void Update(CarUpdate model);
        void Delete(int id);
        CarDto GetById(int id);
        IEnumerable<CarDto> GetAll();
    }
}
