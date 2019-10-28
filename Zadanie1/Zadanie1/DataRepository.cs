using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;

namespace Zadanie1
{
    public class DataRepository : IDataRepository
    {
        public DataContext DataContext { get; set; }

        public DataRepository(DataFill dataFill, DataContext dataContext)
        {
            DataContext = dataContext;
            dataFill.Fill(dataContext);
        }

        public DataRepository(DataContext dataContext) => DataContext = dataContext;

        #region Katalog
        public void AddKatalog(Katalog katalog, int id)
        {
            DataContext.katalogi.Add(id, katalog);
        }

        public void AddKatalog(string tytul, string opis, string autor, int id)
        {
            Katalog katalog = new Katalog(tytul, opis, autor, id);
            AddKatalog(katalog, id);
        }

        public Katalog GetKatalog(int id) => DataContext.katalogi[id];

        public IEnumerable<Katalog> GetAllKatalog() => DataContext.katalogi.Values;

        public void UpdateKatalog(Katalog katalog, int id) => DataContext.katalogi[id] = katalog;

        public void DeleteKatalog(int id) => DataContext.katalogi.Remove(id);
        #endregion

        #region Wykaz
        public void AddWykaz(Wykaz wykaz) => DataContext.wykazy.Add(wykaz);

        public Wykaz GetWykaz(int id) => DataContext.wykazy[id];
        #endregion
    }
}
