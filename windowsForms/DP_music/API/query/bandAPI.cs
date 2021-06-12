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
    public static class bandAPI
    {
        private readonly static string basedURL = "http://164.90.166.133:7402/api/";
        private readonly static string localURL = "https://localhost:44304/api/";

        public static async Task<List<Band>> getBands(string genreId = "")
        {
            try
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
            catch
            {
                return new List<Band>();
            }
        }

        public static async Task<Band> getBand(string genreId)
        {
            try
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
                                return JsonConvert.DeserializeObject<Band>(data);
                            }
                        }
                    }
                }
                return new Band();
            }
            catch
            {
                return new Band();
            }
        }
    }
}
