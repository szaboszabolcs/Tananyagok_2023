using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Euroskills.Models
{
    public partial class Versenyzo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string SzakmaId { get; set; }
        public string OrszagId { get; set; }
        public int Pont { get; set; }

        [JsonIgnore]


        public virtual Orszag Orszag { get; set; }
        public virtual Szakma Szakma { get; set; }
    }
}
