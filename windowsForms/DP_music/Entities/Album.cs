using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.Entities
{
    public class Album
    {
        public string id;
        public string name;
        public string bandId;
        public int year;
        public string description;
        public string image;
        public string file;

        public Album() { }

        public Album(string id, string name, string bandId, int year, string description, string image)
        {
            this.id = id;
            this.name = name;
            this.bandId = bandId;
            this.year = year;
            this.description = description;
            this.image = image;
        }
    }
}
