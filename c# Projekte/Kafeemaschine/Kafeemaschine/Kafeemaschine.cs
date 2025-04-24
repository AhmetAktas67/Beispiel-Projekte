using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafeemaschine
{
    internal class Kafeemaschine
    {
        public double WASSER { get; private set; }
        public double BOHNEN { get; private set; }

        public double GesamtMengeKafeeProduziert { get; private set; }

        private const double MAX_WASSER =2500;
        private const double MAX_BOHNEN=2500;


        public Kafeemaschine() 
        {
            WASSER =0;
            BOHNEN =0;
            GesamtMengeKafeeProduziert = 0;
        }



        public double WasserAuffuellen(double menge)
        {
            double platzfrei = MAX_WASSER - WASSER;
            double tatsaechlich_Gefüllt=menge-platzfrei;

            WASSER = WASSER + tatsaechlich_Gefüllt;

            


            return tatsaechlich_Gefüllt;
        }


        public double BohnenAuffuellen(double menge)
        {
            double platzFrei = MAX_BOHNEN - BOHNEN;
            double tatsaechlichGefuellt = Math.Min(menge, platzFrei);
            BOHNEN += tatsaechlichGefuellt;
            return tatsaechlichGefuellt;
        }


        public bool MacheKaffee(double menge, double verhaeltnisWasserBohnen)
        {
            // Gesamtverhältnis: z.B. bei 2 => 2 Teile Wasser, 1 Teil Bohnen
            double bohnenMenge = menge / (verhaeltnisWasserBohnen + 1);
            double wasserMenge = menge - bohnenMenge;

            if (WASSER >= wasserMenge && BOHNEN >= bohnenMenge)
            {
                WASSER -= wasserMenge;
                BOHNEN -= bohnenMenge;
                GesamtMengeKafeeProduziert += menge / 1000.0; 
                return true;
            }
            return false;
        }











            public void Maschineausgeben()
        {
            Console.WriteLine($"Wasser:{WASSER} Bohnen:{BOHNEN} GesamtMengeproduziert:{GesamtMengeKafeeProduziert}");
        }


    }
    
}
