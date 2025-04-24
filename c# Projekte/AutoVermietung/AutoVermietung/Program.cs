using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVermietung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Autovermietung vermietung = new Autovermietung("Super Cars", "Musterstraße 1, 12345 Stadt", 5);

            // Erstelle Autos und füge sie zum Fuhrpark hinzu
            vermietung.Fuhrpark[0] = new Auto("BMW", "X5", 400, 80) { Fahrzeugart = Fahrzeugart.SUV };
            vermietung.Fuhrpark[1] = new Auto("Audi", "A6", 250, 70) { Fahrzeugart = Fahrzeugart.Limousine };
            vermietung.Fuhrpark[2] = new Auto("Volkswagen", "Passat", 200, 60) { Fahrzeugart = Fahrzeugart.Kombi };
            vermietung.Fuhrpark[3] = new Auto("Mercedes", "V-Class", 300, 90) { Fahrzeugart = Fahrzeugart.Van };
            vermietung.Fuhrpark[4] = new Auto("Ford", "Focus", 150, 50) { Fahrzeugart = Fahrzeugart.Kombi };

            // Erstelle Kunden
            vermietung.KundenHinzufuegen(new Kunde("Max Mustermann", "Beispielstraße 1, 12345 Musterstadt"));
            vermietung.KundenHinzufuegen(new Kunde("Erika Mustermann", "Beispielstraße 2, 12345 Musterstadt"));

            bool weiter = true;

            while (weiter)
            {
                Console.WriteLine("\n1. Fuhrpark anzeigen\n2. Auto mieten\n3. Beenden");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    vermietung.FuhrparkAnzeigen();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Wählen Sie ein Auto aus:");
                    for (int i = 0; i < vermietung.Fuhrpark.Length; i++)
                    {
                        if (vermietung.Fuhrpark[i] != null && vermietung.Fuhrpark[i].Status == Fahrzeugstatus.Verfügbar)
                        {
                            Console.WriteLine($"{i + 1}. {vermietung.Fuhrpark[i].Marke} {vermietung.Fuhrpark[i].Modell} ({vermietung.Fuhrpark[i].MietpreisProTag} EUR/Tag)");
                        }
                    }

                    int autoAuswahl = int.Parse(Console.ReadLine()) - 1;

                    if (vermietung.Fuhrpark[autoAuswahl].Status == Fahrzeugstatus.Verfügbar)
                    {
                        // Wähle einen Kunden aus
                        Console.WriteLine("Wählen Sie einen Kunden aus:");
                        for (int i = 0; i < vermietung.Kunden.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {vermietung.Kunden[i]}");
                        }

                        int kundenAuswahl = int.Parse(Console.ReadLine()) - 1;
                        Kunde ausgewaehlterKunde = vermietung.Kunden[kundenAuswahl];

                        // Mietdauer eingeben
                        Console.WriteLine("Geben Sie die Mietdauer in Tagen ein:");
                        int mietdauer = int.Parse(Console.ReadLine());

                        // Erstelle den Vermietungsvorgang
                        Vermietungsvorgang vorgang = new Vermietungsvorgang(vermietung.Fuhrpark[autoAuswahl], ausgewaehlterKunde, mietdauer);

                        // Ändere den Fahrzeugstatus
                        vermietung.Fuhrpark[autoAuswahl].Status = Fahrzeugstatus.Vermietet;

                        // Zeige die Zusammenfassung des Vermietungsvorgangs
                        vorgang.VermietungZusammenfassung();
                    }
                    else
                    {
                        Console.WriteLine("Dieses Auto ist bereits vermietet.");
                    }
                }
                else if (option == "3")
                {
                    weiter = false;
                }
            }
    }   }
}
