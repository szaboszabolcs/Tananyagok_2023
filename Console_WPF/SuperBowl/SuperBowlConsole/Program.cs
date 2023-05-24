using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperBowlConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Record> versenyzok = new List<Record>();
            StreamReader reader = new StreamReader("SuperBowl.txt");
            reader.ReadLine();
            while(!reader.EndOfStream)
            {
                string[] mezok = reader.ReadLine().Split(';');
                Record egyRecord = new Record(new RomaiSorszam(mezok[0]), mezok[1], mezok[2], mezok[3], mezok[4], mezok[5], mezok[6], int.Parse(mezok[7]));
                versenyzok.Add(egyRecord);
            }
            reader.Close();
            Console.WriteLine($"4. feladat: Döntők száma: {versenyzok.Count}");
            // 5. feladat //
            int pontKulonbseg = 0;
            foreach (var item in versenyzok)
            {
                string[] pontok = item.Eredmeny.Split('-');
                pontKulonbseg += int.Parse(pontok[0]) - int.Parse(pontok[1]);
            }
            Console.WriteLine($"5. feladat: Átlagos pontkülönbség: {Math.Round((double)pontKulonbseg/versenyzok.Count, 1)}");

            // 6. feladat //
            int index = 0;
            for (int i = 0; i < versenyzok.Count; i++)
            {
                if (versenyzok[index].NezoSzam < versenyzok[i].NezoSzam)
                {
                    index = i;
                }
            }
            string[] szerzettPontok = versenyzok[index].Eredmeny.Split('-');
            Console.WriteLine("6. feladat: Legmagasabb nézőszám a döntők során: ");
            Console.WriteLine($"\tSorszám (dátum): {versenyzok[index].Ssz.ArabSsz} ({versenyzok[index].Datum})");
            Console.WriteLine($"\tGyőztes csapat: {versenyzok[index].GyoztesNeve}, szerzett pontok: {szerzettPontok[0]} ");
            Console.WriteLine($"\tVesztes csapat: {versenyzok[index].VesztesNeve}, szerzett pontok: {szerzettPontok[1]} ");
            Console.WriteLine($"\tHelyszín: {versenyzok[index].Helyszin}");
            Console.WriteLine($"\tVáros, állam: {versenyzok[index].VarosAllam}");
            Console.WriteLine($"\tNézőszám: {versenyzok[index].NezoSzam}");
            //7. feladat //
            Dictionary<string,int> CsapatokReszvetele = new Dictionary<string,int>();
            StreamWriter writer = new StreamWriter("SuperBowlNew.txt");
            writer.WriteLine("Ssz;Dátum;Győztes;Eredmény;Vesztes;Nézőszám");
            foreach (var item in versenyzok)
            {
                if (CsapatokReszvetele.ContainsKey(item.GyoztesNeve))
                {
                    CsapatokReszvetele[item.GyoztesNeve] += 1;
                }
                else
                {
                    CsapatokReszvetele[item.GyoztesNeve] = 1;
                }
                if (CsapatokReszvetele.ContainsKey(item.VesztesNeve))
                {
                    CsapatokReszvetele[item.VesztesNeve] += 1;
                }
                else
                {
                    CsapatokReszvetele[item.VesztesNeve] = 1;
                }
                writer.WriteLine($"{item.Ssz.ArabSsz};{item.Datum};{item.GyoztesNeve} ({CsapatokReszvetele[item.GyoztesNeve]});{item.Eredmeny};{item.VesztesNeve} ({CsapatokReszvetele[item.VesztesNeve]});{item.NezoSzam}");
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
