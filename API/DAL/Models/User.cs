using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class User
    {
        public User()
        {
            Reflection = new HashSet<Reflection>();
            Selected = new HashSet<Selected>();
        }

        public string Id { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Reflection> Reflection { get; set; }
        public virtual ICollection<Selected> Selected { get; set; }
    }
}
