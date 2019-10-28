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
        void AddWykaz(Wykaz wykaz);

        Katalog GetKatalog(int id);
  
        IEnumerable<Katalog> GetAllKatalog();

        void UpdateKatalog(Katalog katalog, int id);

        void DeleteKatalog(int id);
    }
}
