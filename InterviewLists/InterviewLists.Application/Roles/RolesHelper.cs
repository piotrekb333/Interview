using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace InterviewLists.Application.Roles
{
    public static class RolesHelper
    {
        public static bool IsAdmin(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(m => m.Type == "groups" && m.Value == "77614eaf-038a-4812-b252-99fbe9a7e217") !=null;
        }
    }
}
