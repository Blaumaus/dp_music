using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.API
{
    public class postLogin
    {
        public bool data;
        public int statusCode;
        public string errorMessage;

        public postLogin(bool data, int statusCode, string errorMessage)
        {
            this.data = data;
            this.statusCode = statusCode;
            this.errorMessage = errorMessage;
        }
    }
}
