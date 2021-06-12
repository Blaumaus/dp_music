using DP_music.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.API.query
{
    public static class genreAPI
    {
        private readonly static string basedURL = "http://164.90.166.133:7402/api/";
        private readonly static string localURL = "https://localhost:44304/api/";

        public static async Task<List<Genre>> GetAllGenres()
        {
            try
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
                                return JsonConvert.DeserializeObject<List<Genre>>(data);
                            }
                        }
                    }
                }
                return new List<Genre>();
            }
            catch
            {
                return new List<Genre>();
            }

        }

        public static async Task<Genre> GetGenre(string id)
        {
            try
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
            catch
            {
                return new Genre();
            }
        }
    }
}
