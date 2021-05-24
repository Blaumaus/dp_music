using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.Entities
{
    public class User
    {
        public int id;
        public string userName;
        public string email;
        public string password;

        public User(int id, string userName, string email, string password)
        {
            this.id = id;
            this.userName = userName;
            this.email = email;
            this.password = password;
        }
    }
}
