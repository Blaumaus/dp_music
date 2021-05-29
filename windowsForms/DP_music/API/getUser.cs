using DP_music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.API
{
    public class getUser
    {
        public User data;
        public int statusCode;
        public string errorMessage;
        public string token;

        public getUser(User data, int statusCode, string errorMessage)
        {
            this.data = data;
            this.statusCode = statusCode;
            this.errorMessage = errorMessage;
        }
    }
}
