using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public override string UserName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
