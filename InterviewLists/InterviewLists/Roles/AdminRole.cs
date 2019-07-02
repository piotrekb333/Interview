using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewLists.Roles
{
    public static class AdminRole
    {
        public static string Name => "Admin";

        public static void Build(AuthorizationPolicyBuilder builder) =>
            builder.RequireClaim("groups", "77614eaf-038a-4812-b252-99fbe9a7e217");
    }
}
