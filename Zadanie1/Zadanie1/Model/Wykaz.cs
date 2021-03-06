using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie1
{
    public class Wykaz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Wykaz(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public Wykaz() {}

        public override string ToString()
        {
            return $"Imie: { Imie } | Nazwisko: { Nazwisko }";
        }
    }
}
