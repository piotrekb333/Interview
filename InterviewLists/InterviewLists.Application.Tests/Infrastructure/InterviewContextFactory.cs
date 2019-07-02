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
                new Artist { FirstName="test",Id=2,UserId="123" },
                new Artist { FirstName="test2",Id=3 },
            });

            context.Trips.AddRange(new[] {
                new Trip { Country="test",Id=2,UserId="123" },
                new Trip { Country="test2",Id=3 },
            });

            context.CarMakes.AddRange(new[] {
                new CarMake { Title="testmake1",Id=2 },
                new CarMake { Title="testmake2",Id=3 },
            });

            context.CarModels.AddRange(new[] {
                new CarModel { Title="testmodel1",Id=2,CarMakeId=2 },
                new CarModel { Title="testmodel2",Id=3,CarMakeId=3 },
            });

            context.Cars.AddRange(new[] {
                new Car { Country="test",Id=2,CarMakeId=2,CarModelId=2,UserId="123" },
                new Car { Country="test2",Id=3,CarMakeId=3,CarModelId=3 },
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
