using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class Composition
    {
        public Composition()
        {
            Reflection = new HashSet<Reflection>();
            Selected = new HashSet<Selected>();
        }

        public string Id { get; set; }
        public string AlbumId { get; set; }
        public string Name { get; set; }
        public string BandId { get; set; }
        public string GenreId { get; set; }
        public int Year { get; set; }
        public string Lyrics { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public virtual Album Album { get; set; }
        public virtual Band Band { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Reflection> Reflection { get; set; }
        public virtual ICollection<Selected> Selected { get; set; }
    }
}
