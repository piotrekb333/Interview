using AutoMapper;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.ModelCar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarModelService(IInterviewDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<CarModelDto> GetByMakeId(int makeId)
        {
            var entities = _mapper.Map<IEnumerable<CarModelDto>>(_dbContext.CarModels.Where(m=>m.CarMakeId== makeId).AsNoTracking());
            return entities;
        }
    }
}
