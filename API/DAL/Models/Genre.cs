using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class Genre
    {
        public Genre()
        {
            Bandgenre = new HashSet<Bandgenre>();
            Composition = new HashSet<Composition>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Bandgenre> Bandgenre { get; set; }
        public virtual ICollection<Composition> Composition { get; set; }
    }
}
