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
    public static class recordAPI
    {
        private readonly static string basedURL = "http://164.90.166.133:7402/api/";
        private readonly static string localURL = "https://localhost:44304/api/";

        public static async Task<List<Record>> getRecords()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(basedURL + "Composition/All"))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return JsonConvert.DeserializeObject<List<Record>>(data);
                            }
                        }
                    }
                }
                return new List<Record>();
            }
            catch
            {
                return new List<Record>();
            }
        }

        public static async Task<List<Record>> getRecords(string albumId, string bandId="")
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(basedURL + "Composition?albumId=" + albumId + "&bandId=" + bandId))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                return JsonConvert.DeserializeObject<List<Record>>(data);
                            }
                        }
                    }
                }
                return new List<Record>();
            }
            catch
            {
                return new List<Record>();
            }
        }
    }
}
