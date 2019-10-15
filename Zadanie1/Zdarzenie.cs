using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Zdarzenie
    {
        private Wykaz wykaz;
        private OpisStanu opisStanu;
        private DateTime dataWypozyczenia;
        private DateTime dataZwrotu;

        Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataWypozyczenia, DateTime dataZwrotu)
        {
            this.wykaz = wykaz;
            this.opisStanu = opisStanu;
            this.dataWypozyczenia = dataWypozyczenia;
            this.dataZwrotu = dataZwrotu;
        }
    }
}
