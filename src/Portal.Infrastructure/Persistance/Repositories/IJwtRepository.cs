using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.Persistance.Repositories
{
   public interface IJwtRepository
    {
        string Generate(User user);
    }
}
