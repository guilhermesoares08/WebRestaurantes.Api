using Microsoft.AspNetCore.Identity;

namespace WebRestaurantes.Domain
{
    public class UserRole
    {
        public int RoleId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }

        public UserRole Clone()
        {
            UserRole obj = new UserRole();

            obj.RoleId = this.RoleId;

            obj.UserId = this.UserId;

            obj.User = this.User.Clone();

            obj.Role = this.Role.Clone();

            return obj;
        }
    }
}