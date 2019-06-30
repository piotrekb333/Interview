using InterviewLists.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Persistence
{
    public class InterviewDbContextFactory : DesignTimeDbContextFactoryBase<InterviewDbContext>
    {
        protected override InterviewDbContext CreateNewInstance(DbContextOptions<InterviewDbContext> options)
        {
            return new InterviewDbContext(options);
        }
    }
}
