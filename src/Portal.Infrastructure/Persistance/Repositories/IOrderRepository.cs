using Portal.Domain;
using Portal.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public interface IOrderRepository
    {
       Task<int> CreateOrder(Order order);
       Task<bool> EditOrder(Order order);
       Task<Order> FindByID(int Id);
    }
}
