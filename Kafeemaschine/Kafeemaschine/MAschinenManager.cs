using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafeemaschine
{
    internal class MAschinenManager
    {
        public void KaffeemaschinenAngleichen(Kafeemaschine maschine1, Kafeemaschine maschine2)
        {
            // Wasser angleichen
            double minWasser = Math.Min(maschine1.WASSER, maschine2.WASSER);
            maschine1.WasserAuffuellen(minWasser - maschine1.WASSER);
            maschine2.WasserAuffuellen(minWasser - maschine2.WASSER);

            // Bohnen angleichen
            double minBohnen = Math.Min(maschine1.BOHNEN, maschine2.BOHNEN);
            maschine1.BohnenAuffuellen(minBohnen - maschine1.BOHNEN);
            maschine2.BohnenAuffuellen(minBohnen - maschine2.BOHNEN);
        }




        public void FuellMich(ref Kafeemaschine maschine, double fuellstand)
        {
            if (maschine == null)
            {
                maschine = new Kafeemaschine();
                maschine.WasserAuffuellen(fuellstand);
            }
            else if (maschine.WASSER < fuellstand)
            {
                maschine.WasserAuffuellen(fuellstand - maschine.WASSER);
            }
        }
    }
}
