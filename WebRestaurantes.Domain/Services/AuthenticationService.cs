using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebRestaurantes.Domain
{
    public class AuthenticationService : BaseService<User, IAuthenticationRepository>, IAuthenticationService
    {
        public AuthenticationService(IAuthenticationRepository authenticationRepository) : base(authenticationRepository)
        {

        }

        public User ValidateUser(string email, string password)
        {
            return _repository.ValidateUser(email, password);
        }

        public User GetUserByLogin(string login)
        {
            return _repository.GetUserByLogin(login);
        }

        public async Task<List<UserRole>> GetUserRoleByUserId(int userId)
        {
            return await _repository.GetUserRoleByUserId(userId);
        }

        public User GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }

        public User CreateUser(User user)
        {
            return _repository.CreateUser(user);
        }
    }
}
