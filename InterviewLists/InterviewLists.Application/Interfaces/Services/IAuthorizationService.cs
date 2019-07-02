using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Interfaces.Services
{
    public interface IAuthorizationService
    {
        bool IsAdmin(IEnumerable<Claim> claims);
        bool AllowModifyEntity(IEnumerable<Claim> claims, string entityUserId);
    }
}
