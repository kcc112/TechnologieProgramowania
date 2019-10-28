using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class OpisStanu
    {
        private Katalog ksiazka;
        private double cena;
        private int stanMagazynowy;

        public OpisStanu(Katalog ksiazka, double cena, int stanMagazynowy)
        {
            this.ksiazka = ksiazka;
            this.cena = cena;
            this.stanMagazynowy = stanMagazynowy;
        }
    }
}
