using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class DataRepository
    {
        private DataContext dataContext;

        void AddKatalog(Katalog k)
        {
            dataContext.katalogi.Add(dataContext.katalogi.Count, k);
        }

        Katalog GetKatalog(int id)
        {
            return dataContext.katalogi[id];
        }

        Dictionary<int, Katalog> GetAll()
        {
            return dataContext.katalogi;
        }
    }
}
