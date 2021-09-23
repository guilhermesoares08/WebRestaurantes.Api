using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public interface IAuthenticationService : IBaseService<User>
    {
        User ValidateUser(string login, string password);

        User GetUserByLogin(string login);

        Task<List<UserRole>> GetUserRoleByUserId(int userId);

        User GetUserById(int id);

        User CreateUser(User user);
    }
}
