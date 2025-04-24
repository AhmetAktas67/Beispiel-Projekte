using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVermietung
{
    internal class Kunde
    {
        public string Name { get; set; }
        public string Adresse { get; set; }

        public Kunde(string name, string adresse)
        {
            Name = name;
            Adresse = adresse;
        }

        
    }
}
