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
            DataContext dataContextToSerialize = new DataContext();
            DataContext dataContextDeserialized = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContextToSerialize);

            Wykaz wykaz1 = new Wykaz("Pan Tadeusz1", "Adam Mickiewicz");
            Wykaz wykaz2 = new Wykaz("Pan Tadeusz2", "Adam Mickiewicz");
            Wykaz wykaz3 = new Wykaz("Pan Tadeusz3", "Adam Mickiewicz");

            Katalog katalog1 = new Katalog("Pan Tadeusz1", "opis", "Adam Mickiewicz", 1);
            Katalog katalog2 = new Katalog("Pan Tadeusz2", "opis", "Adam Mickiewicz", 2);
            Katalog katalog3 = new Katalog("Pan Tadeusz3", "opis", "Adam Mickiewicz", 3);

            OpisStanu opisStanu1 = new OpisStanu(katalog1, 1.0, 1);
            OpisStanu opisStanu2 = new OpisStanu(katalog2, 2.0, 2);
            OpisStanu opisStanu3 = new OpisStanu(katalog3, 3.0, 3);

            dataRepository.AddWykaz(wykaz1);
            dataRepository.AddWykaz(wykaz2);
            dataRepository.AddWykaz(wykaz3);

            dataRepository.AddKatalog(katalog1, 1);
            dataRepository.AddKatalog(katalog2, 2);
            dataRepository.AddKatalog(katalog3, 3);

            dataRepository.AddOpisStanu(opisStanu1);
            dataRepository.AddOpisStanu(opisStanu2);
            dataRepository.AddOpisStanu(opisStanu3);


            OwnSerializer.Serialize(dataContextToSerialize, "test.txt");
            OwnSerializer.Deserialize(dataContextDeserialized, "test.txt");


            Console.WriteLine(dataContextDeserialized.wykazy[0].Imie);
            Console.WriteLine(dataContextDeserialized.wykazy[1].Imie);
            Console.WriteLine(dataContextDeserialized.wykazy[2].Imie);


            Console.WriteLine(dataContextDeserialized.katalogi[1].Tytul);
            Console.WriteLine(dataContextDeserialized.katalogi[2].Tytul);
            Console.WriteLine(dataContextDeserialized.katalogi[3].Tytul);

            Console.WriteLine(dataContextDeserialized.opisyStanu[0].Cena);
            Console.WriteLine(dataContextDeserialized.opisyStanu[1].Cena);
            Console.WriteLine(dataContextDeserialized.opisyStanu[2].Cena);

        }
    }
}
