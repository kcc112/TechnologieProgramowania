using System;

namespace Zadanie1
{
    public class ZdarzenieKupno : Zdarzenie
    {
        public ZdarzenieKupno(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZakup) : base(wykaz, opisStanu, dataZakup) { }
        public ZdarzenieKupno() : base() { }
    }
}