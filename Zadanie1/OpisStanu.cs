using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class OpisStanu
    {
        private Katalog ksiazka;
        private int cena;
        private int stanMagazynowy;

        OpisStanu(Katalog ksiazka, int cena, int stanMagazynowy)
        {
            this.ksiazka = ksiazka;
            this.cena = cena;
            this.stanMagazynowy = stanMagazynowy;
        }
    }
}
