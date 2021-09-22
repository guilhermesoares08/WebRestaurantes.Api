using System.ComponentModel.DataAnnotations.Schema;

namespace WebRestaurantes.Domain
{
    public class User
    {
        public User()
        {
            Id = 0;
            IsActive = true;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string VendorId { get; set; }

        [NotMapped]
        public int RoleId { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public Role Role { get; set; }

        public User Clone()
        {
            User obj = new User();

            obj.Id = this.Id;
            obj.UserName = this.UserName;
            obj.Login = this.Login;
            obj.Email = this.Email;
            obj.Password = this.Password;
            obj.RoleId = this.RoleId;
            obj.VendorId = this.VendorId;
            if(this.Role != null)
            {
                obj.Role = this.Role.Clone();
            }           

            return obj;
        }
    }
}
