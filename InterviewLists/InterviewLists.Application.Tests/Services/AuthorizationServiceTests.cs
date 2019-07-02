using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace InterviewLists.Application.Tests.Services
{
    public class AuthorizationServiceTests
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationServiceTests()
        {
            _authorizationService = new AuthorizationService();
        }

        [Fact]
        public void IsAdminTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
                new Claim("groups", "77614eaf-038a-4812-b252-99fbe9a7e217")
            };
            var result = _authorizationService.IsAdmin(claims);
            Assert.True(result);
        }

        [Fact]
        public void AllowModifyEntityTest()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "123"),
            };
            var result = _authorizationService.AllowModifyEntity(claims,"123");
            Assert.True(result);
        }
    }
}
