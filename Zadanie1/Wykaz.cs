using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Wykaz
    {
        private String imie;
        public string Imie
        {
            get { return imie; }
            set { this.imie = value; }
        }

        private String nazwisko;
        public string Nazwisko
        {
            get { return nazwisko; }
            set { this.nazwisko = value; }
        }

        Wykaz(String imie, String nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
