using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebRestaurantes.Domain
{
    public class Role 
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Role Clone()
        {
            Role r = new Role();

            r.Id = this.Id;
            r.Description = this.Description;

            return r;
        }
    }
}