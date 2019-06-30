using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Persistence
{
    public class InterviewInitializer
    {

        public static void Initialize(InterviewDbContext context)
        {
            var initializer = new InterviewInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(InterviewDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
