using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Szabó_Szabolcs_backend_uszoeb.Models
{
    public partial class Szamok
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Versenyzoid { get; set; }

        [JsonIgnore]

        public virtual Versenyzok Versenyzo { get; set; }
    }
}
