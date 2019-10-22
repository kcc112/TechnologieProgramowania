using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Testy")]

namespace Zadanie1
{
    class DataRepository
    {
        private DataContext dataContext;

        public DataRepository(DataContext context)
        {
            this.dataContext = context;
        }

        public void AddKatalog(Katalog k, int id)
        {
            dataContext.katalogi.Add(id, k);
        }

        public Katalog GetKatalog(int id)
        {
            return dataContext.katalogi[id];
        }

        public Dictionary<int, Katalog> GetAllKatalog()
        {
            return dataContext.katalogi;
        }
    }
}
