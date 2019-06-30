using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Persistence.Configurations
{
    public class CarMakeConfiguration : IEntityTypeConfiguration<CarMake>
    {
        public void Configure(EntityTypeBuilder<CarMake> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).HasMaxLength(200);
        }
    }
}
