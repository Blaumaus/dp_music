using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.Entities
{
    public class Band
    {
        public string id;
        public string genreId;
        public string name;
        public string image;
        public string countryCode;
        public DateTime foundationData;
        public string description;
        public string file;

        public Band(string id, string genreId, string name, string image, string countryCode, DateTime foundationData, string description, string file)
        {
            this.id = id;
            this.genreId = genreId;
            this.name = name;
            this.image = image;
            this.countryCode = countryCode;
            this.foundationData = foundationData;
            this.description = description;
            this.file = file;
        }

        public Band() { }
    }
}
