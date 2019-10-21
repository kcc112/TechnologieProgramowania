using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class WypelnianieStalymi : DataFill
    {

        void DataFill.Fill(DataContext context)
        {
            Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
            katalogi.Add(new Katalog("Pan Tadeusz",
                                    "To spisana trzynastozgloskowcem, zawarta w dwunastu ksiegach opowiesc o szlachcie polskiej poczatku XIX wieku.",
                                    "Adam Mickiewicz"));

            katalogi.Add(new Katalog("Kordian",
                                    "Dramat romantyczny autorstwa Juliusza Slowackiego.",
                                    "Juliusz Slowacki"));

            katalogi.Add(new Katalog("Dziady",
                                    "To dzielo niezwykle bogate w przerozne tresci oraz poruszajace liczne, skomplikowane oraz zaangazowane spolecznie, zagadnienia.",
                                    "Adam Mickiewicz"));

            List<OpisStanu> opisyStanu = new List<OpisStanu>();
            opisyStanu.Add(new OpisStanu(k1, 25.99, 28));
            opisyStanu.Add(new OpisStanu(k1, 23.99, 27));
            opisyStanu.Add(new OpisStanu(k3, 89.99, 4));
            opisyStanu.Add(new OpisStanu(k2, 14.99, 66));
            opisyStanu.Add(new OpisStanu(k3, 79.99, 3));
            opisyStanu.Add(new OpisStanu(k1, 26.99, 25));
            opisyStanu.Add(new OpisStanu(k3, 75.99, 1));
            opisyStanu.Add(new OpisStanu(k1, 22.99, 22));
            opisyStanu.Add(new OpisStanu(k2, 12.99, 64));
            opisyStanu.Add(new OpisStanu(k1, 28.99, 21));

            List<Wykaz> wykazy = new List<Wykaz>();
            wykazy.Add(new Wykaz("Jan", "Kowalski"));
            wykazy.Add(new Wykaz("Andrzej", "Wojtkiewicz"));
            wykazy.Add(new Wykaz("Dawid", "Papis"));
            wykazy.Add(new Wykaz("Maciej", "Pastuszak"));
            wykazy.Add(new Wykaz("Mateusz", "Polowczyk"));
            wykazy.Add(new Wykaz("Kamil", "Kijek"));
            wykazy.Add(new Wykaz("Piotr", "Sulkowski"));
            wykazy.Add(new Wykaz("Bartosz", "Bilinski"));

            ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();
            zdarzenia.Add(new Zdarzenie(w1, o1, new DateTime(2017, 10, 1, 12, 4, 18)));
            zdarzenia.Add(new Zdarzenie(w2, o1, new DateTime(2017, 12, 11, 6, 14, 32)));
            zdarzenia.Add(new Zdarzenie(w3, o2, new DateTime(2018, 3, 15, 11, 5, 38)));
            zdarzenia.Add(new Zdarzenie(w1, o3, new DateTime(2018, 5, 21, 10, 32, 21)));
            zdarzenia.Add(new Zdarzenie(w4, o4, new DateTime(2018, 11, 28, 16, 00, 8)));
            zdarzenia.Add(new Zdarzenie(w5, o5, new DateTime(2019, 8, 4, 8, 45, 12)));
            zdarzenia.Add(new Zdarzenie(w1, o6, new DateTime(2019, 10, 7, 9, 28, 59)));
            zdarzenia.Add(new Zdarzenie(w6, o7, new DateTime(2019, 10, 18, 7, 58, 57)));
            zdarzenia.Add(new Zdarzenie(w6, o8, new DateTime(2019, 10, 21, 11, 28, 0)));
            zdarzenia.Add(new Zdarzenie(w3, o9, new DateTime(2018, 12, 20, 10, 1, 2)));
            zdarzenia.Add(new Zdarzenie(w3, o10, new DateTime(2017, 2, 22, 8, 11, 12)));

            context(wykazy, katalogi, zdarzenia, opisyStanu);
        }

        WypelnianieStalymi()
        {
            DataContext dt = new DataContext();
            DataFill.Fill(dt);
        }
    }
}
