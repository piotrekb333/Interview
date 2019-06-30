using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Persistence.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Country).HasMaxLength(100);
            builder.Property(e => e.CarMakeId).IsRequired();
            builder.Property(e => e.CarModelId).IsRequired();

            builder.HasOne(d => d.CarMake)
           .WithMany(p => p.Cars)
           .HasForeignKey(d => d.CarMakeId)
           .HasConstraintName("FK_Cars_Makes");

            builder.HasOne(d => d.CarModel)
            .WithMany(p => p.Cars)
            .HasForeignKey(d => d.CarModelId)
            .HasConstraintName("FK_Cars_Models");
        }
    }
}
