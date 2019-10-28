using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class ZdarzenieKupno : Zdarzenie
    {
        public ZdarzenieKupno(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZakup) : base(wykaz, opisStanu, dataZakup) { }
    }
}