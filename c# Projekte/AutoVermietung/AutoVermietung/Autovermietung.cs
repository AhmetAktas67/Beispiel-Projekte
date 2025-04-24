using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVermietung
{
    internal class Autovermietung
    {
        public string Name { get; set; }
        public string Adresse { get; set; }
        public Auto[] Fuhrpark { get; set; }
        public List<Kunde> Kunden { get; set; }

        public Autovermietung(string name, string adresse, int anzahlfahrzeuge)
        {
            Name = name;
            Adresse = adresse;
            Fuhrpark = new Auto[anzahlfahrzeuge];
            Kunden = new List<Kunde>();
        }

        public void FuhrparkAnzeigen()
        {
            Console.WriteLine("\n---------------------------- FUHRPARK ----------------------------");
            Console.WriteLine($"{"#",3} {"Marke",-10} {"Modell",-10} {"Typ",-10} {"PS",4} {"Preis/Tag",10} {"Status",12}");
            Console.WriteLine("-----------------------------------------------------------------");



            for (int i = 0; i < Fuhrpark.Length; i++)
            {
                if (Fuhrpark[i] != null)
                {
                    Fuhrpark[i].AutoInfo();
                }
            }
        }

        public void KundenHinzufuegen(Kunde kunde)
        {
            Kunden.Add(kunde);
        }


    }
}