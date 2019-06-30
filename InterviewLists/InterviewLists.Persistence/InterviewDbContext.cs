using InterviewLists.Application.Interfaces;
using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewLists.Persistence
{
    public class InterviewDbContext : DbContext, IInterviewDbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options)
    : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarMake> CarMakes { get; set; }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InterviewDbContext).Assembly);
        }

    }
}
