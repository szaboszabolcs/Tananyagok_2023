using System;
using System.Collections.Generic;

#nullable disable

namespace Szabó_Szabolcs_backend_iskolak.Models
{
    public partial class Iskolalogok
    {
        public int Id { get; set; }
        public int IskolaId { get; set; }
        public byte[] Logo { get; set; }

        public virtual Iskolak Iskolak { get; set; }
    }
}
