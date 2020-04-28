using Portal.Domain;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Infrastructure.Persistance.Repositories
{
    public class UserService : IUserRepository
    {
        PortalDbContext _context;
        IJwtRepository _jwtRepository;
        public UserService(PortalDbContext context, IJwtRepository jwtRepository)
        {
            _context = context;
            _jwtRepository = jwtRepository;
        }
        public User GetUserByUsername(User user)
        {
            var model = _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            try
            {
                if (model != null)
                {
                    return model;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Login(User user)
        {
            var model = GetUserByUsername(user);
            try
            {
                if (model != null)
                {
                    var token = _jwtRepository.Generate(model);
                    return token;
                }
                else
                {
                    return "unauthorized";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
