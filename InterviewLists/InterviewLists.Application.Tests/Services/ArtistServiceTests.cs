using AutoMapper;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Models.Artist;
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
    public class ArtistServiceTests
    {
        private readonly InterviewDbContext _context;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly IAuthorizationService _authorizationService;

        public ArtistServiceTests()
        {
            _context = InterviewContextFactory.Create();
            _mapper = AutoMapperFactory.Create();
            _authorizationService = new AuthorizationService();
            _artistService = new ArtistService(_context, _mapper, _authorizationService);
        }

        [Fact]
        public void CreateTest()
        {           
            _artistService.Create(new Models.Artist.ArtistCreate
            {
                FirstName = "testnew",               
            },"123");
            var art=_context.Artists.FirstOrDefault(m=>m.FirstName=="testnew");
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
            _artistService.Update(new Models.Artist.ArtistUpdate
            {
                FirstName = "testnew",
                Id = 2
            },claims);
            
            var art = _context.Artists.FirstOrDefault(m => m.Id == 2);
            Assert.Equal("testnew", art.FirstName);
        }

        [Fact]
        public void DeleteTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            _artistService.Delete(2, claims);
            var art = _context.Artists.FirstOrDefault(m => m.Id == 2);
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
            var art=_artistService.GetById(2,claims);
            Assert.Equal(2,art.Id);
            
        }

        [Fact]
        public void GetAllTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            var all=_artistService.GetAll(claims);
            Assert.True(all is IEnumerable<ArtistDto>);
            Assert.True(all.Count() > 0);
            
        }
    }
}
