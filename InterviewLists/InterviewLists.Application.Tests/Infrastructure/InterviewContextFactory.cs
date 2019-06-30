using InterviewLists.Domain.Entities;
using InterviewLists.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Tests.Infrastructure
{
    public class InterviewContextFactory
    {
        public static InterviewDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InterviewDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new InterviewDbContext(options);

            context.Database.EnsureCreated();

            context.Artists.AddRange(new[] {
                new Artist { FirstName="test",Id=2 },
                new Artist { FirstName="test2",Id=3 },
            });
            context.SaveChanges();

            return context;
        }

        public static void Destroy(InterviewDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
