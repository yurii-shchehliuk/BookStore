using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserRoles
    {
        public int UserRolesId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
