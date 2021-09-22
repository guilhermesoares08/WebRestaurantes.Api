using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface IAuthenticationRepository : IBaseRepository<User>
    {
        User ValidateUser(string login, string password);

        User GetUserByLogin(string login);

        Task<List<UserRole>> GetUserRoleByUserId(int userId);

        User GetUserById(int id);

        User CreateUser(User user);
    }
}
