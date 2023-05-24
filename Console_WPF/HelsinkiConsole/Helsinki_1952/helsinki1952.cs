using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki_1952
{
    public class helsinki1952
    {
        public static int HelyezesPontSzamErtek(int helyezes)
        {
            switch (helyezes)
            {
                case 1:
                    {
                        return 7;
                    }
                case 2:
                    {
                        return 5;
                    }
                case 3:
                    {
                        return 4;
                    }
                case 4:
                    {
                        return 3;
                    }
                case 5:
                    {
                        return 2;
                    }
                case 6:
                    {
                        return 1;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public static List<Eredmenyek> AdatokBeolvasasa()
        {
            List<Eredmenyek> adatok = new List<Eredmenyek>();
            StreamReader reader = new StreamReader("helsinki.txt");
            while (!reader.EndOfStream)
            {
                Eredmenyek egyEredmeny = new Eredmenyek((reader.ReadLine()));
                adatok.Add(egyEredmeny);
            }
            return adatok;
        }


        static void Main(string[] args)
        {
            List<Eredmenyek> adatok = AdatokBeolvasasa();

            Console.WriteLine("3. feladat:");
            Console.WriteLine($"A magyar olimpikonok {adatok.Count} pontszerző helyezést értek el.");
            Console.WriteLine("5. feladat:");
            int Pontszam = 0;
            int OsszLetszam = 0;
            foreach (var item in adatok)
            {
                if (item.Sportag == "torna")
                {
                    Pontszam += HelyezesPontSzamErtek(item.Helyezes);
                }
            }
            Console.WriteLine($"A magyarok {Pontszam} pontot szereztek összesen a torna sportágban.");
            Console.WriteLine("6. feladat:");
            Console.WriteLine("7. feladat:");
            StreamWriter writer = new StreamWriter("foglalasok.txt");
            writer.WriteLine($"Szeretnék asztalokat foglalni {OsszLetszam} főre! ");
            writer.Close();
            Console.WriteLine("A foglalasok.txt fájl elkészült.");

            Dictionary<string, int> pontszamokSportagonkent = new Dictionary<string, int>();
            foreach (var item in adatok)
            {
                if (pontszamokSportagonkent.ContainsKey(item.Sportag))
                {
                    pontszamokSportagonkent[item.Sportag] += HelyezesPontSzamErtek(item.Helyezes);
                }
                else
                {
                    pontszamokSportagonkent[item.Sportag] = HelyezesPontSzamErtek(item.Helyezes);
                }
            }
            foreach (var item in pontszamokSportagonkent)
            {
                Console.WriteLine($"{item.Key} {item.Value} pont");
            }

            Console.ReadKey();
        }
    }
}
