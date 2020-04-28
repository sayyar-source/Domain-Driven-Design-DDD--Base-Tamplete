using Portal.Infrastructure.Persistance.Repositories;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortalDbContext _db;
        public UnitOfWork(PortalDbContext db)
        {
            _db = db;
             OrderRepository = new OrderRepository(db);
        }

        public IOrderRepository OrderRepository { get; }

        public async Task<bool> CommitAsync()
        {
           
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
