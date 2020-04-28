using Portal.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infrastructure.Persistance
{
   public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        IOrderRepository OrderRepository { get; }
    }
   
}
