using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterviewLists.Application.Interfaces
{
    public interface IInterviewDbContext
    {
        DbSet<Artist> Artists { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<CarMake> CarMakes { get; set; }
        DbSet<CarModel> CarModels { get; set; }
        DbSet<Trip> Trips { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken= default(CancellationToken));
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
