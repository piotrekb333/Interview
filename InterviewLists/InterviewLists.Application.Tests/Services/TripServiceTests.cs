using AutoMapper;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
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
    public class TripServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITripService _tripService;
        private readonly IAuthorizationService _authorizationService;

        public TripServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _authorizationService = new AuthorizationService();
            _tripService = new TripService(_context, _mapper,_authorizationService);
        }

        [Fact]
        public void CreateTest()
        {
            
            _tripService.Create(new Models.Trip.TripCreate
            {
                Country="testnew",
                
            },"123");
            var art = _context.Trips.FirstOrDefault(m => m.Country == "testnew");
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
            _tripService.Update(new Models.Trip.TripUpdate
            {
                Country = "testnew",
                Id = 2
            }, claims);
            var art = _context.Trips.FirstOrDefault(m => m.Id == 2);
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
            _tripService.Delete(2, claims);
            var art = _context.Trips.FirstOrDefault(m => m.Id == 2);
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
            var trip = _tripService.GetById(2, claims);
            Assert.Equal(2, trip.Id);
        }

        [Fact]
        public void GetAllTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            var all = _tripService.GetAll(claims);
            Assert.True(all is IEnumerable<TripDto>);
            Assert.True(all.Count() > 0);
        }
    }
}
