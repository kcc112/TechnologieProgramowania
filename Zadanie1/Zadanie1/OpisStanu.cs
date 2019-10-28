using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class OpisStanu
    {
        public Katalog Katalog { get; set; }
        public double Cena { get; set; }
        public int Jakosc { get; set; }

        public OpisStanu(Katalog katalog, double cena, int jakosc)
        {
            Katalog = katalog;
            Cena = cena;
            Jakosc = jakosc;
        }

        public override string ToString()
        {
            return $"Cena: { Cena } | Jakosc: { Jakosc } | " + Katalog.ToString();
        }
    }
}
