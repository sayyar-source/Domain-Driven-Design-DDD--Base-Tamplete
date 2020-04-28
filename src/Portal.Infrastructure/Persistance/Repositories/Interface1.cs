using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Infrastructure.Persistance.Repositories
{
   public interface IUserRepository
    {
        User GetUserByUsername(User user);
        string Login(User user);
    }
}
