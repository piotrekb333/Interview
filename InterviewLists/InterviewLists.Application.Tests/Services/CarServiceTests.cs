using AutoMapper;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Car;
using InterviewLists.Application.Models.Trip;
using InterviewLists.Application.Tests.Infrastructure;
using InterviewLists.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace InterviewLists.Application.Tests.Services
{
    public class CarServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        public CarServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _carService = new CarService(_context, _mapper);
        }

        [Fact]
        public void CreateTest()
        {
            _carService.Create(new Models.Car.CarCreate
            {
                Country = "testnew",
            });
            var art = _context.Cars.FirstOrDefault(m => m.Country == "testnew");
            Assert.NotNull(art);
        }

        [Fact]
        public void UpdateTest()
        {
            _carService.Update(new Models.Car.CarUpdate
            {
                Country = "testnew",
                Id = 2
            });
            var art = _context.Cars.FirstOrDefault(m => m.Id == 2);
            Assert.Equal("testnew", art.Country);
        }

        [Fact]
        public void DeleteTest()
        {
            _carService.Delete(2);
            var art = _context.Cars.FirstOrDefault(m => m.Id == 2);
            Assert.Null(art);
        }

        [Fact]
        public void GetByIdTest()
        {
            var art = _carService.GetById(2);
            Assert.Equal(2, art.Id);
        }

        [Fact]
        public void GetAllTest()
        {
            var all = _carService.GetAll();
            Assert.True(all is IEnumerable<CarDto>);
            Assert.True(all.Count() > 0);
        }
    }
}
