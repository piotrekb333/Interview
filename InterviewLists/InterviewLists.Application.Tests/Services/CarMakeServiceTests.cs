using AutoMapper;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.MakeCar;
using InterviewLists.Application.Tests.Infrastructure;
using InterviewLists.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace InterviewLists.Application.Tests.Services
{
    public class CarMakeServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICarMakeService _carMakeService;
        public CarMakeServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _carMakeService = new CarMakeService(_context, _mapper);
        }

        [Fact]
        public void GetAllTest()
        {
            var all = _carMakeService.GetAll();
            Assert.True(all is IEnumerable<CarMakeDto>);
            Assert.True(all.Count() > 0);
        }
    }
}
