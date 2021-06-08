using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.Entities
{
    public class Record
    {
        public string id;
        public string albumId;
        public string name;
        public string bandId;
        public string genreId;
        public int year;
        public string lyrics;
        public string description;
        public string filePath;
        public string file;

        public Record() { }

        public Record(string id, string albumId, string name, string bandId, string genreId, int year, 
            string lyrics, string description, string filePath, string file)
        {
            this.id = id;
            this.albumId = albumId;
            this.name = name;
            this.bandId = bandId;
            this.genreId = genreId;
            this.year = year;
            this.lyrics = lyrics;
            this.description = description;
            this.filePath = filePath;
            this.file = file;
        }
    }
}
