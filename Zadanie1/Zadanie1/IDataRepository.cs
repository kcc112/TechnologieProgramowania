using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    interface IDataRepository
    {
        void AddKatalog(Katalog katalog, int id);
        Katalog GetKatalog(int id);
    }
}
