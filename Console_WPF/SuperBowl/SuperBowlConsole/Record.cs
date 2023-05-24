using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBowlConsole
{
    internal class Record
    {
        public RomaiSorszam Ssz
        {
            get;
            private set;
        }

        public string Datum
        {
            get;
            private set;
        }

        public string GyoztesNeve
        {
            get;
            private set;
        }

        public string Eredmeny
        {
            get;
            private set;
        }

        public string VesztesNeve
        {
            get;
            private set;
        }

        public string Helyszin
        {
            get;
            private set;
        }

        public string VarosAllam
        {
            get;
            private set;
        }

        public int NezoSzam
        {
            get;
            private set;
        }

        public Record(RomaiSorszam ssz, string datum, string gyoztesNeve, string eredmeny, string vesztesNeve, string helyszin, string varosAllam, int nezoSzam)
        {
            Ssz = ssz;
            Datum = datum;
            GyoztesNeve = gyoztesNeve;
            Eredmeny = eredmeny;
            VesztesNeve = vesztesNeve;
            Helyszin = helyszin;
            VarosAllam = varosAllam;
            NezoSzam = nezoSzam;
        }

        public override string ToString()
        {
            return $"{Ssz.RomaiSsz};{Ssz.ArabSsz};{Datum};{GyoztesNeve};{Eredmeny};{VesztesNeve};{Helyszin};{VarosAllam};{NezoSzam}";
        }
    }
}
