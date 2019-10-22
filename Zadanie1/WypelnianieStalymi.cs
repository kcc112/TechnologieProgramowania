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
            context.katalogi.Add(0, new Katalog("Pan Tadeusz",
                                    "To spisana trzynastozgloskowcem, zawarta w dwunastu ksiegach opowiesc o szlachcie polskiej poczatku XIX wieku.",
                                    "Adam Mickiewicz"));
            context.katalogi.Add(1, new Katalog("Kordian",
                        "Dramat romantyczny autorstwa Juliusza Slowackiego.",
                        "Juliusz Slowacki"));

            context.katalogi.Add(2, new Katalog("Dziady",
                                    "To dzielo niezwykle bogate w przerozne tresci oraz poruszajace liczne, skomplikowane oraz zaangazowane spolecznie, zagadnienia.",
                                    "Adam Mickiewicz"));

            context.opisyStanu.Add(new OpisStanu(context.katalogi[0], 25.99, 28));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[0], 23.99, 27));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[2], 89.99, 4));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[1], 14.99, 66));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[2], 79.99, 3));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[1], 26.99, 25));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[2], 75.99, 1));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[0], 22.99, 22));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[2], 12.99, 64));
            context.opisyStanu.Add(new OpisStanu(context.katalogi[0], 28.99, 21));

            context.wykazy.Add(new Wykaz("Jan", "Kowalski"));
            context.wykazy.Add(new Wykaz("Andrzej", "Wojtkiewicz"));
            context.wykazy.Add(new Wykaz("Dawid", "Papis"));
            context.wykazy.Add(new Wykaz("Maciej", "Pastuszak"));
            context.wykazy.Add(new Wykaz("Mateusz", "Polowczyk"));
            context.wykazy.Add(new Wykaz("Kamil", "Kijek"));
            context.wykazy.Add(new Wykaz("Piotr", "Sulkowski"));
            context.wykazy.Add(new Wykaz("Bartosz", "Bilinski"));

            context.zdarzenia.Add(new Zdarzenie(context.wykazy[0], context.opisyStanu[0], new DateTime(2017, 10, 1)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[1], context.opisyStanu[1], new DateTime(2017, 12, 11)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[2], context.opisyStanu[2], new DateTime(2018, 3, 15)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[3], context.opisyStanu[3], new DateTime(2018, 5, 21)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[4], context.opisyStanu[4], new DateTime(2018, 11, 28)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[5], context.opisyStanu[6], new DateTime(2019, 8, 4)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[6], context.opisyStanu[7], new DateTime(2019, 10, 7)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[0], context.opisyStanu[8], new DateTime(2019, 10, 18)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[1], context.opisyStanu[9], new DateTime(2019, 10, 21)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[2], context.opisyStanu[0], new DateTime(2018, 12, 20)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[3], context.opisyStanu[1], new DateTime(2017, 2, 22)));
        }
    }
}
