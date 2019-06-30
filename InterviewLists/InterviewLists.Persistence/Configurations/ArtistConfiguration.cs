using InterviewLists.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Persistence.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Country).HasMaxLength(100);
            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
        }
    }
}
