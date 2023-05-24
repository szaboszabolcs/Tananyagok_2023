using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki_1952
{
    public class Eredmenyek
    {
        public int Helyezes
        {
            get;
            private set;
        }

        public int SportoloSzama
        {
            get;
            private set;
        }

        public string Sportag
        {
            get;
            private set;
        }

        public string VersenySzam
        {
            get;
            private set;
        }

        public int Pontszam
        {
            get;
            set;
        }

        public Eredmenyek(string sor)
        {
            string[] mezok = sor.Split(' ');
            Helyezes = int.Parse(mezok[0]);
            SportoloSzama = int.Parse(mezok[1]);
            Sportag = mezok[2];
            VersenySzam = mezok[3];
        }
    }
}
