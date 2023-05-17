using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Szabó_Szabolcs_backend_uszoeb.Models
{
    public partial class Versenyzok
    {
        public Versenyzok()
        {
            Szamoks = new HashSet<Szamok>();
        }

        public int Id { get; set; }
        public string Nev { get; set; }
        public int OrszagId { get; set; }
        public string Nem { get; set; }

        [JsonIgnore]

        public virtual Orszagok Orszag { get; set; }
        public virtual ICollection<Szamok> Szamoks { get; set; }
    }
}
