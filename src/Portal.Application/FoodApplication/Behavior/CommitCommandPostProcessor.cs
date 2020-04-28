using MediatR.Pipeline;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Behavior
{
    public class CommitCommandPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly PortalDbContext _db;
        public CommitCommandPostProcessor(PortalDbContext db)
        {
            _db = db;
        }
        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
           await _db.SaveChangesAsync();

        }
    }
}
