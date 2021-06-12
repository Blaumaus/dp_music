using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.API
{
    public class postLogin
    {
        public string data;
        public int statusCode;
        public string errorMessage;
        public string token;

        public postLogin() { }

        public postLogin(string data, int statusCode, string errorMessage)
        {
            this.data = data;
            this.statusCode = statusCode;
            this.errorMessage = errorMessage;
        }
    }
}
