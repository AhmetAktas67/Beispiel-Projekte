using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafeemaschine
{
    internal class KafeeGeschaeft
    {

        private double _preisProKg;
        public double PreisProKg {get { return _preisProKg;}
            set
            {
                if (_preisProKg > 4 && _preisProKg < 30)
                {
                    _preisProKg = value;
                }

            }
                
                
                
        }

        public KafeeGeschaeft(double preisprokg) 
        {
            PreisProKg=preisprokg;
        }



        public double kaufeKafee(Kafeemaschine maschine,double menge)
        {
            double aufgefuellt = maschine.BohnenAuffuellen(menge);
            return (aufgefuellt / 1000.0) * PreisProKg;
        } 
    }
}
