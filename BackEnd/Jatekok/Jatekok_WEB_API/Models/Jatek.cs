using System;
using System.Collections.Generic;

#nullable disable

namespace Jatekok_WEB_API.Models
{
    public partial class Jatek
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Megjeleneseve { get; set; }
        public int Ar { get; set; }
        public string Leiras { get; set; }
        public string KepUrl { get; set; }
    }
}
