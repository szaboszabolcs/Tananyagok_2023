using System;
using System.Collections.Generic;

#nullable disable

namespace Szabó_Szabolcs_backend_iskolak.Models
{
    public partial class Iskolak
    {
        public Iskolak()
        {
            Diakoks = new HashSet<Diakok>();
        }

        public int Id { get; set; }
        public int IskolaId { get; set; }
        public string Nev { get; set; }
        public byte[] SmallLogo { get; set; }

        public virtual Iskolalogok Iskola { get; set; }
        public virtual ICollection<Diakok> Diakoks { get; set; }
    }
}
