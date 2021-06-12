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
    public static class albumAPI
    {
        private readonly static string basedURL = "http://164.90.166.133:7402/api/";
        private readonly static string localURL = "https://localhost:44304/api/";

        public static async Task<List<Album>> getAlbums(string bandId = "")
        {
            try
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
            catch
            {
                return new List<Album>();
            }
        }

        public static async Task<Album> getAlbum(string albumId = "")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(basedURL + "Album?bandId=" + albumId))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return JsonConvert.DeserializeObject<Album>(data);
                            }
                        }
                    }
                }
                return new Album();
            }
            catch
            {
                return new Album();
            }
        }
    }
}
