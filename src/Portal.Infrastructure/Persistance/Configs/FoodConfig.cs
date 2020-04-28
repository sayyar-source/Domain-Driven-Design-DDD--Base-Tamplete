using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain;
using Portal.Domain.FoodAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Persistance.Configs
{
    public class FoodConfig : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(f => f.ID).UseHiLo();
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.Name).HasMaxLength(25).IsRequired();
            builder.Property(f => f.Description).HasMaxLength(1000).IsRequired();
            builder.OwnsOne(f => f.Price);
        }
    }
}
