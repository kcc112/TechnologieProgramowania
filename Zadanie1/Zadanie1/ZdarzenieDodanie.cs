using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class ZdarzenieDodanie : Zdarzenie
    {
        public ZdarzenieDodanie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataDodania) : base(wykaz, opisStanu, dataDodania) { }
    }
}
