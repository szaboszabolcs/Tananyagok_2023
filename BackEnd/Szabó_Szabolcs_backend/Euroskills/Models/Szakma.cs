using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Euroskills.Models
{
    public partial class Szakma
    {
        public Szakma()
        {
            Versenyzos = new HashSet<Versenyzo>();
        }

        public string Id { get; set; }
        public string SzakmaNev { get; set; }

        [JsonIgnore]

        public virtual ICollection<Versenyzo> Versenyzos { get; set; }
    }
}
