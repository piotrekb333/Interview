using AutoMapper;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
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
    public class TripServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITripService _tripService;

        public TripServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _tripService = new TripService(_context, _mapper);
        }

        [Fact]
        public void CreateTest()
        {
            _tripService.Create(new Models.Trip.TripCreate
            {
                Country="testnew"
            });
            var art = _context.Trips.FirstOrDefault(m => m.Country == "testnew");
            Assert.NotNull(art);
        }

        [Fact]
        public void UpdateTest()
        {
            _tripService.Update(new Models.Trip.TripUpdate
            {
                Country = "testnew",
                Id = 2
            });
            var art = _context.Trips.FirstOrDefault(m => m.Id == 2);
            Assert.Equal("testnew", art.Country);
        }

        [Fact]
        public void DeleteTest()
        {
            _tripService.Delete(2);
            var art = _context.Trips.FirstOrDefault(m => m.Id == 2);
            Assert.Null(art);
        }

        [Fact]
        public void GetByIdTest()
        {
            var trip = _tripService.GetById(2);
            Assert.Equal(2, trip.Id);
        }

        [Fact]
        public void GetAllTest()
        {
            var all = _tripService.GetAll();
            Assert.True(all is IEnumerable<TripDto>);
            Assert.True(all.Count() > 0);
        }
    }
}
