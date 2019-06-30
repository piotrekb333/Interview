using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Persistence.Configurations
{
    public class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).HasMaxLength(200);
            builder.Property(e => e.CarMakeId).IsRequired();

            builder.HasOne(d => d.CarMake)
            .WithMany(p => p.CarModels)
            .HasForeignKey(d => d.CarMakeId)
            .HasConstraintName("FK_Models_Makes");
        }
    }
}
