using AutoMapper;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.ModelCar;
using InterviewLists.Application.Tests.Infrastructure;
using InterviewLists.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace InterviewLists.Application.Tests.Services
{
    public class CarModelServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICarModelService _carModelService;

        public CarModelServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _carModelService = new CarModelService(_context, _mapper);
        }

        [Fact]
        public void GetByMakeIdTest()
        {
            var all = _carModelService.GetByMakeId(2);
            Assert.True(all is IEnumerable<CarModelDto>);
            Assert.True(all.Count() > 0);
            Assert.Equal("testmodel1", all.First().Title);
        }
    }
}
