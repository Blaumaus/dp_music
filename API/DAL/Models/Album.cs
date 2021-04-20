using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class Album
    {
        public Album()
        {
            Composition = new HashSet<Composition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BandId { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        public virtual Band Band { get; set; }
        public virtual ICollection<Composition> Composition { get; set; }
    }
}
