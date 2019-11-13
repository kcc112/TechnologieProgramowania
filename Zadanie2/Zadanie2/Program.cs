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

            dataRepository.AddWykaz(wykaz1);
            dataRepository.AddWykaz(wykaz2);
            dataRepository.AddWykaz(wykaz3);

            Console.WriteLine(dataContextToSerialize.wykazy.Count);

            OwnSerializer.Serialize(dataContextToSerialize, "test.txt");
            OwnSerializer.Deserialize(dataContextDeserialized, "test.txt");

            Console.WriteLine(dataContextDeserialized.wykazy.Count);

            Console.WriteLine(dataContextDeserialized.wykazy[0].Imie);
            Console.WriteLine(dataContextDeserialized.wykazy[1].Imie);
            Console.WriteLine(dataContextDeserialized.wykazy[2].Imie);

        }
    }
}
