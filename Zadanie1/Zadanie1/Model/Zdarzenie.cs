using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie1
{
    public abstract class Zdarzenie
    {
        public Wykaz Wykaz { get; set; }
        public OpisStanu OpisStanu { get; set; }
        public DateTime Data { get; set; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime data)
        {
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            Data = data;
        }

        public Zdarzenie() { }

        public override string ToString()
        {
            return $"Data: { Data } | " + Wykaz.ToString() + OpisStanu.ToString();
        }
    }
}