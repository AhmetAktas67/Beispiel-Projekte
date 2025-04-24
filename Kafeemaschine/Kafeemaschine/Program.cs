using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafeemaschine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kafeemaschine maschine1 = new Kafeemaschine();
            Kafeemaschine maschine2 = new Kafeemaschine();
            Kafeemaschine neueMaschine = null;

            KafeeGeschaeft geschaeft = new KafeeGeschaeft(18); // z. B. 18€/kg
            MAschinenManager manager = new MAschinenManager();

            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("\n==== Kaffee-Menü ====");
                Console.WriteLine("1. Wasser auffüllen");
                Console.WriteLine("2. Bohnen auffüllen");
                Console.WriteLine("3. Kaffee machen");
                Console.WriteLine("4. Füllstände anzeigen");
                Console.WriteLine("5. Maschinen angleichen");
                Console.WriteLine("6. Bohnen kaufen");
                Console.WriteLine("7. Neue Maschine erzeugen und befüllen");
                Console.WriteLine("0. Beenden");
                Console.Write("Auswahl: ");
                string eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        Console.Write("Wieviel Wasser (in g) möchten Sie auffüllen? ");
                        if (double.TryParse(Console.ReadLine(), out double wasser))
                        {
                            double gefuellt = maschine1.WasserAuffuellen(wasser);
                            Console.WriteLine($"Tatsächlich aufgefüllt: {gefuellt}g Wasser.");
                        }
                        break;

                    case "2":
                        Console.Write("Wieviel Bohnen (in g) möchten Sie auffüllen? ");
                        if (double.TryParse(Console.ReadLine(), out double bohnen))
                        {
                            double gefuellt = maschine1.BohnenAuffuellen(bohnen);
                            Console.WriteLine($"Tatsächlich aufgefüllt: {gefuellt}g Bohnen.");
                        }
                        break;

                    case "3":
                        Console.Write("Wieviel Kaffee möchten Sie machen? (in g): ");
                        double menge = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Verhältnis Wasser:Bohnen (z.B. 2 für doppelt so viel Wasser): ");
                        double verhältnis = Convert.ToDouble(Console.ReadLine());

                        bool erfolg = maschine1.MacheKaffee(menge, verhältnis);
                        Console.WriteLine(erfolg ? "Kaffee wurde zubereitet!" : "Nicht genug Zutaten.");
                        break;

                    case "4":
                        Console.WriteLine("📟 Füllstände Maschine 1:");
                        maschine1.Maschineausgeben();
                        Console.WriteLine("\n📟 Füllstände Maschine 2:");
                        maschine2.Maschineausgeben();
                        break;

                    case "5":
                        manager.KaffeemaschinenAngleichen(maschine1, maschine2);
                        Console.WriteLine("Füllstände wurden angeglichen.");
                        break;

                    case "6":
                        Console.Write("Wieviel Bohnen möchten Sie kaufen? (in g): ");
                        double kaufmenge = Convert.ToDouble(Console.ReadLine());
                        double preis = geschaeft.kaufeKafee(maschine1, kaufmenge);
                        Console.WriteLine($"Bohnen gekauft für: {preis:0.00} €.");
                        break;

                    case "7":
                        Console.Write("Gewünschter Wasserfüllstand für neue Maschine (in g): ");
                        double fuellstand = Convert.ToDouble(Console.ReadLine());
                        manager.FuellMich(ref neueMaschine, fuellstand);
                        Console.WriteLine("Neue Maschine wurde erstellt und befüllt:");
                        neueMaschine.Maschineausgeben();
                        break;

                    case "0":
                        run = false;
                        Console.WriteLine("👋 Tschüss! Vielen Dank für Ihren Besuch!");
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe.");
                        break;

                        
                }
                Console.ReadKey();
            }
        }
    }
}
