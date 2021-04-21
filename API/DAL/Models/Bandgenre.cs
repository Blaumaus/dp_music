using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class Bandgenre
    {
        public string BandId { get; set; }
        public string GenreId { get; set; }

        public virtual Band Band { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
