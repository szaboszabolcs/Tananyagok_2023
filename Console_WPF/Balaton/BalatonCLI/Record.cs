using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class Record
    {
        public string Adoszam
        {
            get;
            private set;
        }

        public string Nev
        {
            get;
            private set;
        }

        public string Hazszam
        {
            get;
            private set;
        }

        public char Adosav
        {
            get;
            set;
        }

        public int Alapterulet
        {
            get;
            set;
        }

        public Record(string sor)
        {
            string[] mezok = sor.Split(' ');
            Adoszam = mezok[0];
            Nev = mezok[1];
            Hazszam = mezok[2];
            Adosav = char.Parse(mezok[3]);
            Alapterulet = int.Parse(mezok[4]);
        }
    }
}
