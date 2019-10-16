using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Katalog
    {
        private String nazwa;
        public string Nazwa
        {
            get { return nazwa; }
            set { this.nazwa = value; }
        }

        private String opis;
        public string Opis
        {
            get { return opis; }
            set { this.opis = value; }
        }

        Katalog(String nazwa, String opis)
        {
            this.nazwa = nazwa;
            this.opis = opis;
        }
    }
}
