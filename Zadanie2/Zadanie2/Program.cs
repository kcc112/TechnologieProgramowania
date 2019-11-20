using System;
using System.IO;
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

            OpisStanu opisStanu1 = new OpisStanu(katalog1, 1.1, 1);
            OpisStanu opisStanu2 = new OpisStanu(katalog2, 2.2, 2);
            OpisStanu opisStanu3 = new OpisStanu(katalog3, 3.3, 3);


            Zdarzenie zdarzenie1 = new ZdarzenieDodanie(wykaz1, opisStanu1, new DateTime(2017, 2, 22));
            Zdarzenie zdarzenie2 = new ZdarzenieKupno(wykaz2, opisStanu2, new DateTime(2017, 2, 22));
            Zdarzenie zdarzenie3 = new ZdarzenieDodanie(wykaz3, opisStanu3, new DateTime(2017, 2, 22));


            dataRepository.AddWykaz(wykaz1);
            dataRepository.AddWykaz(wykaz2);
            dataRepository.AddWykaz(wykaz3);

            dataRepository.AddKatalog(katalog1, 1);
            dataRepository.AddKatalog(katalog2, 2);
            dataRepository.AddKatalog(katalog3, 3);

            dataRepository.AddOpisStanu(opisStanu1);
            dataRepository.AddOpisStanu(opisStanu2);
            dataRepository.AddOpisStanu(opisStanu3);

            dataRepository.AddZdarzenie(zdarzenie1);
            dataRepository.AddZdarzenie(zdarzenie2);
            dataRepository.AddZdarzenie(zdarzenie3);

            File.Delete("own_format.txt");
            Stream stream = File.Open("own_format.txt", FileMode.Create, FileAccess.ReadWrite);
            OwnFormatterBase.Serialize(dataContextToSerialize, stream);
            stream.Close();

            Stream streamDeserialize = File.Open("own_format.txt", FileMode.Open, FileAccess.Read);
            OwnFormatterBase.Deserialize(dataContextDeserialized, streamDeserialize);
            streamDeserialize.Close();


            Console.WriteLine(dataContextDeserialized.wykazy[0].Imie);
            Console.WriteLine(dataContextDeserialized.wykazy[1].Imie);
            Console.WriteLine(dataContextDeserialized.wykazy[2].Imie);


            Console.WriteLine(dataContextDeserialized.katalogi[1].Tytul);
            Console.WriteLine(dataContextDeserialized.katalogi[2].Tytul);
            Console.WriteLine(dataContextDeserialized.katalogi[3].Tytul);

            Console.WriteLine(dataContextDeserialized.opisyStanu[0].Cena);
            Console.WriteLine(dataContextDeserialized.opisyStanu[1].Cena);
            Console.WriteLine(dataContextDeserialized.opisyStanu[2].Cena);

            Console.WriteLine(dataContextDeserialized.zdarzenia[0].Wykaz.Imie);
            Console.WriteLine(dataContextDeserialized.zdarzenia[1].Wykaz.Imie);
            Console.WriteLine(dataContextDeserialized.zdarzenia[2].Wykaz.Imie);

        }
    }
}
