using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalatonCLI
{
    public class BalatonCLI
    {
        public static int A_adosav = 800, B_adosav = 600, C_adosav = 100;

        public static List<Record> AdatokBeolvasasa()
        {
            List<Record> adatok = new List<Record>();
            StreamReader reader = new StreamReader("utca.txt");
            string[] adosavok = reader.ReadLine().Split(' ');
            A_adosav = int.Parse(adosavok[0]);
            B_adosav = int.Parse(adosavok[1]);
            C_adosav= int.Parse(adosavok[2]);
            while (!reader.EndOfStream)
            {
                Record egyRecord = new Record(reader.ReadLine());
                adatok.Add(egyRecord);
            }
            return adatok;
        }


        // 4. feladat //
        public static int Ado(char adoSav, int terulet)
        {
            int fizentendoAdo = 0;
            if (adoSav == 'A')
            {
                fizentendoAdo = terulet * A_adosav;
            }
            else if (adoSav == 'B')
            {
                fizentendoAdo = terulet * B_adosav;
            }
            else
            {
                fizentendoAdo = terulet * C_adosav;
            }
            if (fizentendoAdo < 10000)
            {
                return 0;
            }
            else
            {
                return fizentendoAdo;
            }
        }



        static void Main(string[] args)
        {
            List<Record> adatok = AdatokBeolvasasa();

            // 2. feladat //
            Console.WriteLine($"2. feladat: A mintában {adatok.Count} telek szerepel.");

            // 3. feladat //
            Console.Write($"3. feladat: Egy tulajdonos adószáma: ");
            string bekertAdoszam = Console.ReadLine();
            bool talalt = false;
            foreach (var item in adatok)
            {
                if (item.Adoszam == bekertAdoszam)
                {
                    talalt = true;
                    Console.WriteLine($"{item.Nev} utca {item.Hazszam}");
                }
            }
            if (!talalt)
            {
                Console.WriteLine("Nem szerepel az adatállományban!");
            }

            // 5. feladat //
            Console.WriteLine("5. feladat: ");
            Dictionary<char, int> telkekSzamaAdosavonkent = new Dictionary<char, int>();
            Dictionary<char, int> fizetendoAdosavonkent = new Dictionary<char, int>();
            foreach (var item in adatok)
            {
                if (telkekSzamaAdosavonkent.ContainsKey(item.Adosav))
                {
                    telkekSzamaAdosavonkent[item.Adosav] += 1;
                }
                else
                {
                    telkekSzamaAdosavonkent[item.Adosav] = 1;
                }

                if (fizetendoAdosavonkent.ContainsKey(item.Adosav))
                {
                    fizetendoAdosavonkent[item.Adosav] += Ado(item.Adosav, item.Alapterulet);
                }
                else
                {
                    fizetendoAdosavonkent[item.Adosav] = Ado(item.Adosav, item.Alapterulet);
                }
            }
            foreach (var item in telkekSzamaAdosavonkent)
            {
                Console.WriteLine($"{item.Key} sávba {item.Value} telek esik, az adó {fizetendoAdosavonkent[item.Key]} Ft.");
            }

            // 6. feladat //
            Console.WriteLine("6. feladat: ");
            StreamWriter writer = new StreamWriter("teljes.txt");
            foreach (var item in adatok)
            {
                writer.WriteLine($"{item.Adoszam} {item.Nev} {item.Hazszam} {item.Adosav} {item.Alapterulet} {Ado(item.Adosav, item.Alapterulet)}");
            }

            Console.ReadKey();
        }
    }
}
