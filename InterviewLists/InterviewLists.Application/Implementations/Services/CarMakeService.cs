using AutoMapper;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.MakeCar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class CarMakeService : ICarMakeService
    {
        private readonly IInterviewDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarMakeService(IInterviewDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<CarMakeDto> GetAll()
        {
            var entities = _mapper.Map<IEnumerable<CarMakeDto>>(_dbContext.CarMakes.AsNoTracking());
            return entities;
        }
    }
}
