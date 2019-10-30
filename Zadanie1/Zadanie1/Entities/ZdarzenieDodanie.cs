using System;

namespace Zadanie1
{
    public class ZdarzenieDodanie : Zdarzenie
    {
        public ZdarzenieDodanie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataDodania) : base(wykaz, opisStanu, dataDodania) { }
    }
}
