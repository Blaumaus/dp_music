using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.Entities
{
    public class Genre
    {
        public string id;
        public string name;
        public string description;
        public string image;

        public Genre(string id, string name, string description, string image)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.image = image;
        }

        public Genre() { }

    }
}
