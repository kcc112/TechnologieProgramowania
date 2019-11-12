using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;
using Zadanie1.Serializer;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            IDataRepository dataRepository = new DataRepository(dataContext);
            Katalog katalog = new Katalog("pan tadeusz", "opis", "adam mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            Wykaz wykaz = new Wykaz("pan tadeusz", "adam mickiewicz");
            DateTime date = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie = new ZdarzenieDodanie(wykaz, opisStanu, date);
            dataRepository.AddZdarzenie(zdarzenie);

            OwnSerializer.Serialize(dataContext, "test.txt");


            Console.WriteLine("XD");
            Console.ReadLine();
        }
    }
}
