using Portal.Domain;
using Portal.Domain.OrderAggregate;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PortalDbContext _db;
        public OrderRepository(PortalDbContext db)
        {
            _db = db;
        }
        public Task<int> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditOrder(Order order)
        {
             _db.Orders.Update(order);
            return true;
        }

        public Task<Order> FindByID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
