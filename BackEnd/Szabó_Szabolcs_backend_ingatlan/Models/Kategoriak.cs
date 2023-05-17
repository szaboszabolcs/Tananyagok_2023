using System;
using System.Collections.Generic;

#nullable disable

namespace Szabó_Szabolcs_backend_ingatlan.Models
{
    public partial class Kategoriak
    {
        public Kategoriak()
        {
            Ingatlanoks = new HashSet<Ingatlanok>();
        }

        public int Id { get; set; }
        public string Nev { get; set; }

        public virtual ICollection<Ingatlanok> Ingatlanoks { get; set; }
    }
}
