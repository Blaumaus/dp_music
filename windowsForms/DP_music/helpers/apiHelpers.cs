using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DP_music.API;
using System.Net;
using DP_music.Entities;

namespace DP_music.helpers
{
    public static class apiHelpers
    {
        private readonly static string basedURL = "http://164.90.166.133:7402/api/";
        private readonly static string localURL = "https://localhost:44304/api/";

        public static async Task<string> GetAllGenres()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(basedURL + "Genre"))
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

        public static async Task<Genre> GetGenre(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(basedURL + "Genre/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return JsonConvert.DeserializeObject<Genre>(data);
                        }
                    }
                }
            }
            return new Genre();
        }
        public static async Task<postLogin> IsLogin(string userLogin)
        {
            HttpContent userInfo = new StringContent(userLogin, Encoding.UTF8, "application/json");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.PostAsync(basedURL + "Account/Login", userInfo))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            var cookie = res.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
                            if (data != null)
                            {
                                postLogin loginInfo = JsonConvert.DeserializeObject<postLogin>(data);
                                if (loginInfo.data != "false")
                                {
                                    loginInfo.token = cookieToString(cookie.First());
                                }
                                return loginInfo;
                            }
                        }
                    }
                }
                return new postLogin();
            }
            catch
            {
                return new postLogin();
            }
        }

        private static string cookieToString(string cookie)
        {
            int semicolon = cookie.IndexOf(';');
            return cookie.Substring(0, semicolon);
        }

        public static async Task<User> GetUser(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, basedURL + "User");
                httpRequestMessage.Headers.Add("Cookie", token);

                //using (HttpResponseMessage res = await client.GetAsync(localURL + "User"))
                using (HttpResponseMessage res = await client.SendAsync(httpRequestMessage))
                {
                    using (HttpContent content = res.Content)
                    {
                        var user = await content.ReadAsStringAsync();
                        if (user != null)
                        {
                            return convertToUser(user);
                        }
                    }
                }
            }
            return new User();
        }

        private static User convertToUser(string user)
        {
            var userStatus = JsonConvert.DeserializeObject<getUser>(user);
            if (userStatus.errorMessage == null)
            {
                return userStatus.data;
            }
            return new User();
        }

        public static async Task<postLogin> ValidateUserName(string userName)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(basedURL + "UserValidation/ValidateUserName/" + userName))
                {
                    using (HttpContent content = res.Content)
                    {
                        var valid = await content.ReadAsStringAsync();
                        if (valid != null)
                        {
                            return JsonConvert.DeserializeObject<postLogin>(valid);
                        }
                    }
                }
            }
            return new postLogin();
        }

        public static async Task<postLogin> ValidateEmail(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(basedURL + "UserValidation/ValidateEmail/" + email))
                {
                    using (HttpContent content = res.Content)
                    {
                        var valid = await content.ReadAsStringAsync();
                        if (valid != null)
                        {
                            return JsonConvert.DeserializeObject<postLogin>(valid);
                        }
                    }
                }
            }
            return new postLogin();
        }

        public static async Task<bool> Registration(string user)
        {
            HttpContent userInfo = new StringContent(user, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(basedURL + "Account/Register", userInfo))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data == null || data == "")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static async Task<bool> deleteAccount(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, basedURL + "Account/Logout");
                httpRequestMessage.Headers.Add("Cookie", token);

                //using (HttpResponseMessage res = await client.GetAsync(localURL + "User"))
                using (HttpResponseMessage res = await client.SendAsync(httpRequestMessage))
                {
                    if(res.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static async Task<List<Band>> getBand(string genreId="")
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(basedURL + "Band?genreId=" + genreId))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return JsonConvert.DeserializeObject<List<Band>>(data);
                        }
                    }
                }
            }
            return new List<Band>();
        }

        public static async Task<List<Album>> getAlbums(string bandId="")
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(basedURL + "Album?bandId=" + bandId))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return JsonConvert.DeserializeObject<List<Album>>(data);
                        }
                    }
                }
            }
            return new List<Album>();
        }
    }
}
