using InterviewLists.Domain.Entities;
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

            SeedCarMakes(context);
            SeedCarModels(context);
        }
        public void SeedCarMakes(InterviewDbContext context)
        {
            var makes = new[]
            {
               new CarMake {Title="BMW" },
               new CarMake {Title="Audi" },
               new CarMake {Title="Volvo" }
            };
            context.CarMakes.AddRange(makes);
        }

        public void SeedCarModels(InterviewDbContext context)
        {
            var models = new[]
            {
               new CarModel {Title="A4",CarMakeId=1 },
               new CarModel {Title="A5",CarMakeId=1 },
               new CarModel {Title="A6",CarMakeId=1 },

               new CarModel {Title="M3",CarMakeId=2 },
               new CarModel {Title="M4",CarMakeId=2 },
               new CarModel {Title="M5",CarMakeId=2 },

               new CarModel {Title="S70",CarMakeId=3 },
               new CarModel {Title="S80",CarMakeId=3 },
               new CarModel {Title="S90",CarMakeId=3 },
            };
            context.CarModels.AddRange(models);

        }
    }
}
