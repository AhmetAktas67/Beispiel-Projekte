using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoVermietung
{
    public enum Fahrzeugart
    {
        SUV,
        Kombi,
        Van,
        Limousine
    }

    public enum Fahrzeugstatus
    {
        Verfügbar,
        Vermietet,
        Werkstatt
    }

    internal class Auto
    {

        public string Marke { get; set; }
        public string Modell { get; set; }
        public int PS { get; set; }
        public string Farbe { get; set; }
        public Fahrzeugart Fahrzeugart { get; set; }
        public Fahrzeugstatus Status { get; set; } = Fahrzeugstatus.Verfügbar;
        public double MietpreisProTag { get; set; }

        // Konstruktor
        public Auto(string marke, string modell, int ps, double mietpreisProTag)
        {
            Marke = marke;
            Modell = modell;
            PS = ps;
            MietpreisProTag = mietpreisProTag;
        }

        public void AutoInfo()
        {

            Console.WriteLine($"{+ 1,3} {Marke,-10} {Modell,-10} {Fahrzeugart,-10} {PS,4} {MietpreisProTag,10:F2} € {Status,12}");
        }
    }
}

