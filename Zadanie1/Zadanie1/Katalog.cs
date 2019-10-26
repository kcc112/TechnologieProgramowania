using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Katalog
    {
        private string tytul;
        private string autor;
        private string opis;

        public string Tytul
        {
            get { return tytul; }
            set { this.tytul = value; }
        }

        public string Opis {
            get { return opis; }
            set { this.opis = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { this.autor = value; }
        }

        public Katalog(string tytul, string opis, string autor)
        {
            this.tytul = tytul;
            this.opis = opis;
            this.autor = autor;
        }
    }
}
