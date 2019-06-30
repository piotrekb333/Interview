using InterviewLists.Application.Models.MakeCar;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface ICarMakeService
    {
        IEnumerable<CarMakeDto> GetAll();
    }
}
