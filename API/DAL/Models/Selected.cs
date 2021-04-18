using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL
{
    public partial class Selected
    {
        public string UserId { get; set; }
        public string CompositionId { get; set; }

        public virtual Composition Composition { get; set; }
        public virtual User User { get; set; }
    }
}
