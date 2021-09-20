using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebRestaurantes.Domain
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}