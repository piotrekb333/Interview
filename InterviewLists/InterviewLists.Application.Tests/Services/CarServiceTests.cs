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
using System.Security.Claims;
using System.Text;
using Xunit;

namespace InterviewLists.Application.Tests.Services
{
    public class CarServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICarService _carService;
        private readonly IAuthorizationService _authorizationService;

        public CarServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _authorizationService = new AuthorizationService();

            _carService = new CarService(_context, _mapper,_authorizationService);
        }

        [Fact]
        public void CreateTest()
        {            
            _carService.Create(new Models.Car.CarCreate
            {
                Country = "testnew",
            },"123");
            var art = _context.Cars.FirstOrDefault(m => m.Country == "testnew");
            Assert.NotNull(art);
            
        }

        [Fact]
        public void UpdateTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            _carService.Update(new Models.Car.CarUpdate
            {
                Country = "testnew",
                Id = 2
            }, claims);
            var art = _context.Cars.FirstOrDefault(m => m.Id == 2);
            Assert.Equal("testnew", art.Country);
        }

        [Fact]
        public void DeleteTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            _carService.Delete(2, claims);
            var art = _context.Cars.FirstOrDefault(m => m.Id == 2);
            Assert.Null(art);
        }

        [Fact]
        public void GetByIdTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            var art = _carService.GetById(2, claims);
            Assert.Equal(2, art.Id);
        }

        [Fact]
        public void GetAllTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            var all = _carService.GetAll(claims);
            Assert.True(all is IEnumerable<CarDto>);
            Assert.True(all.Count() > 0);
        }
    }
}
