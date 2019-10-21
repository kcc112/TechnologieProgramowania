using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Katalog
    {
        private String tytul;
        public string Tytul
        {
            get { return tytul; }
            set { this.tytul = value; }
        }

        private String opis;
        public string Opis {
            get { return opis; }
            set { this.opis = value; }
        }

        private String autor;
        public string Autor
        {
            get { return autor }
            set { this.autor = value; }
        }

        Katalog(String nazwa, String opis, String autor)
        {
            this.tytul = tytul;
            this.opis = opis;
            this.autor = autor;
        }
    }
}
