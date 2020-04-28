using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.Persistance.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.ID).UseHiLo();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.OwnsOne(u => u.Address);
            builder.OwnsOne(u => u.SocialAddress);
        }
    }
}
