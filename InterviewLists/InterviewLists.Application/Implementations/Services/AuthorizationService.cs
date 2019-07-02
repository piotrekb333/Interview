using InterviewLists.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Implementations.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public bool IsAdmin(IEnumerable<Claim> claims)
        {
            if (claims == null)
                return false;
            return claims.FirstOrDefault(m => m.Type == "groups" && m.Value == "77614eaf-038a-4812-b252-99fbe9a7e217") != null;
        }
        public bool AllowModifyEntity(IEnumerable<Claim> claims,string entityUserId)
        {
            if (claims == null || claims.Count()==0)
                return false;
            string userid = claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier)?.Value;
            return userid == entityUserId || IsAdmin(claims);
        }

        
    }
}
