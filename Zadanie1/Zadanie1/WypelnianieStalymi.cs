using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Testy")]

namespace Zadanie1
{
    class WypelnianieStalymi : DataFill
    {
        public void Fill(DataContext context)
        {
            context.katalogi.Add(0, new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 0));
            context.katalogi.Add(1, new Katalog("Kordian", "opis", "Juliusz Slowacki", 1));
            context.katalogi.Add(2, new Katalog("Dziady", "opis", "Adam Mickiewicz", 2));
        }
    }
}
