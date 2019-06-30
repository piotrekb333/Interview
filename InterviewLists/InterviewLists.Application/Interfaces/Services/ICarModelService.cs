using InterviewLists.Application.Models.ModelCar;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface ICarModelService
    {
        IEnumerable<CarModelDto> GetByMakeId(int makeId);
    }
}
