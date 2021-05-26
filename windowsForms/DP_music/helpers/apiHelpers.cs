using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DP_music.API;

namespace DP_music.helpers
{
    public static class apiHelpers
    {
        private readonly static string basedURL = "http://164.90.166.133//api/";
        private readonly static string localURL = "https://localhost:44304/api/";

        public static async Task<string> GetAllGenres()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(localURL + "Genre"))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<string> IsLogin(string userLogin)
        {
            HttpContent userInfo = new StringContent(userLogin, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(localURL + "Account/Login", userInfo))
                {
                    using (HttpResponseMessage responce = await client.GetAsync(localURL + "Account/IsAuthorizedUser"))
                    {
                        var dataAutor = await responce.Content.ReadAsStringAsync();
                        var isAutorized = JsonConvert.DeserializeObject<postLogin>(dataAutor);
                        if(isAutorized.data)
                        {
                            
                        }
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return data;
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }

        public static async Task<string> GetUser()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(localURL + "Account/IsAuthorizedUser"))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
