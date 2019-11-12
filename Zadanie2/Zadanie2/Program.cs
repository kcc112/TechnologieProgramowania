using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            Wykaz wykaz = new Wykaz("Kamil", "Celejewski");
            Console.WriteLine(wykaz.Imie);
        }
    }
}
