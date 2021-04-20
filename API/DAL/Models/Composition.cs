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
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int BandId { get; set; }
        public int GenreId { get; set; }
        public int Year { get; set; }
        public string Lyrics { get; set; }
        public string Description { get; set; }

        public virtual Album Album { get; set; }
        public virtual Band Band { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Reflection> Reflection { get; set; }
        public virtual ICollection<Selected> Selected { get; set; }
    }
}
