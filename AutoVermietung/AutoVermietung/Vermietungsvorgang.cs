using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVermietung
{
    internal class Vermietungsvorgang
    {
        public Auto Auto { get; set; }
        public Kunde Kunde { get; set; }
        public int MietdauerInTagen { get; set; }
        public double Gesamtpreis { get; set; }

        public Vermietungsvorgang(Auto auto, Kunde kunde, int mietdauerInTagen)
        {
            Auto = auto;
            Kunde = kunde;
            MietdauerInTagen = mietdauerInTagen;
            Gesamtpreis = Auto.MietpreisProTag * MietdauerInTagen;
        }

        public void VermietungZusammenfassung()
        {
            Console.WriteLine("\nVermietung Zusammenfassung:");
            Console.WriteLine($"Kunde: {Kunde}");
            Console.WriteLine($"Auto: {Auto.Marke} {Auto.Modell}");
            Console.WriteLine($"Mietdauer: {MietdauerInTagen} Tage");
            Console.WriteLine($"Gesamtpreis: {Gesamtpreis} EUR");
        }
    }
}
