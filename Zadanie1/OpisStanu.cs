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
        private DateTime dataZakupu;
        private int stanMagazynowy;
        private int cenaNetto;
        private int podatek;

        OpisStanu(Katalog ksiazka, DateTime dataZakupu, int stanMagazynowy, int cenaNetto, int podatek)
        {
            this.ksiazka = ksiazka;
            this.dataZakupu = dataZakupu;
            this.stanMagazynowy = stanMagazynowy;
            this.cenaNetto = opis;
            this.podatek = podatek;
        }
    }
}
