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
        private DateTime dataZakupu;

        Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZakupu)
        {
            this.wykaz = wykaz;
            this.opisStanu = opisStanu;
            this.dataZakupu = dataZakupu;
        }
    }
}
