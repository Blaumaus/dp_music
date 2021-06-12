using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.Entities
{
    public class User
    {
        public string id;
        public string login;
        public string role;
        public string token;

        public User() 
        {
            this.login = "guest";
        }

        public User(string id, string login, string role)
        {
            this.id = id;
            this.login = login;
            this.role = role;
        }
    }
}
