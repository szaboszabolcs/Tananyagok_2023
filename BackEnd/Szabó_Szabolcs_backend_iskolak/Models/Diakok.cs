using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Szabó_Szabolcs_backend_iskolak.Models
{
    public partial class Diakok
    {
        public int Id { get; set; }
        public string Tanev { get; set; }
        public int IskolaId { get; set; }
        public string OktatasiAzonosito { get; set; }
        public string Nev { get; set; }
        public string Osztaly { get; set; }

        [JsonIgnore]

        public virtual Iskolak Iskola { get; set; }
    }
}
