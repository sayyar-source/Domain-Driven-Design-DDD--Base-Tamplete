using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain;
using Portal.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.Persistance.Configs
{
    class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(order => order.ID).UseHiLo();
            
        }
    }

    class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
         builder.HasKey(orderItem => new { orderItem.OrderId, orderItem.FoodId });
            builder.Property(item => item.ID).UseHiLo();
        }
    }
}
