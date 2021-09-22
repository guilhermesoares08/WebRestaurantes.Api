using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class AuthenticationRepository : BaseRepository<User>, IAuthenticationRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public AuthenticationRepository(WebRestaurantesContext webRestaurantesContext) : base(webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public User ValidateUser(string login, string password)
        {
            IQueryable<User> query = _webRestaurantesContext.User;

            User objRet = null;
            
            foreach (var item in query)
            {
                if (item.Login.ToLower().Equals(login.ToLower()) && item.Password.Equals(password))
                {
                    objRet = item.Clone();
                    objRet.Password = GenerateMd5(objRet.Password);                    
                }
            }

            var userRole = GetUserRoleByUserId(objRet.Id);
            if (userRole != null)
            {
                objRet.Role = GetRoleById(userRole.Result.First().RoleId);
            }

            return objRet;
        }

        public User GetUserByLogin(string login)
        {
            IQueryable<User> query = _webRestaurantesContext.User;           

            query = query.AsNoTracking().Where(c => c.Login.ToLower().Equals(login.ToLower()));

            if (query == null)
            {
                return null;
            }

            query = query.Include(q => q.Role);
            if (query != null && query.First() != null)
            {
                User retObj = query.First().Clone();
                retObj.Password = GenerateMd5(retObj.Password);
                return retObj;
            }

            return query.FirstOrDefault();
        }

        public async Task<List<UserRole>> GetUserRoleByUserId(int userId)
        {
            IQueryable<UserRole> query = _webRestaurantesContext.UserRole;

            query = query.AsNoTracking().Where(r => r.UserId.Equals(userId));

            if (query == null)
            {
                return null;
            }
            //sem AsNoTracking = pode manipular
            return await query.ToListAsync();
        }

        public User GetUserRoleById(int id)
        {
            IQueryable<User> query = _webRestaurantesContext.User;

            query = query.AsNoTracking().Where(r => r.Id.Equals(id));

            if (query == null)
            {
                return null;
            }

            User retObj = query.First().Clone();
            retObj.Password = GenerateMd5(retObj.Password);
            return retObj;
        }

        public User CreateUser(User user)
        {
            var dbResponse = _webRestaurantesContext.Add(user);

            if (dbResponse == null || (dbResponse != null && dbResponse.Entity == null))
            {
                return null;
            }
            _webRestaurantesContext.SaveChanges();

            User retObj = dbResponse.Entity.Clone();
            retObj.Password = GenerateMd5(retObj.Password);
            
            return retObj;
        }

        private static string GenerateMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            //format tostring
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public User GetUserById(int id)
        {
            IQueryable<User> query = _webRestaurantesContext.User;

            query = query.AsNoTracking().Where(r => r.Id.Equals(id));

            if (query == null)
            {
                return null;
            }

            User retObj = query.AsNoTracking().First().Clone();

            retObj.Password = GenerateMd5(retObj.Password);

            return retObj;
        }

        private Role GetRoleById(int id)
        {
            IQueryable<Role> query = _webRestaurantesContext.Role;

            query = query.AsNoTracking().Where(r => r.Id.Equals(id));

            if (query == null)
            {
                return null;
            }

            return query.First();
        }
    }
}
