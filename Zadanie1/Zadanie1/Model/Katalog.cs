using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie1
{
    public class Katalog
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Opis { get; set; }
        public int Id { get; set; }

        public Katalog(string tytul, string opis, string autor, int id)
        {
            Tytul = tytul;
            Opis = opis;
            Autor = autor;
            Id = id;
        }

        public Katalog() { }

        public override string ToString()
        {
            return $"Tytul: { Tytul } | Autor: { Autor } | Opis: { Opis } | Id: { Id }";
        }
    }
}
