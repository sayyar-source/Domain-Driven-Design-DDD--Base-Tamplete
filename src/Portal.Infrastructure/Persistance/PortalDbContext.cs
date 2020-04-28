using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portal.Domain;
using Portal.Domain.FoodAggregate;
using Portal.Domain.OrderAggregate;
using Portal.Infrastructure.Persistance;
using Portal.Infrastructure.Persistance.Configs;
using Portal.Persistance.Configs;
using System;

namespace Portal.Persisatance
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
              : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }
       public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //  builder.ApplyConfiguration(new BaseEntityConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new FoodConfig());
            builder.ApplyConfiguration(new OrderConfig());

            base.OnModelCreating(builder);


        }

    }
}
