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

        public IEnumerable<Wykaz> GetAllWykaz() => DataContext.wykazy;

        public void UpdateWykaz(Wykaz wykaz, int id) => DataContext.wykazy[id] = wykaz;

        public void DeleteWykaz(Wykaz wykaz) => DataContext.wykazy.Remove(wykaz);
        #endregion

        #region OpisStanu
        public void AddOpisStanu(OpisStanu opisStanu) => DataContext.opisyStanu.Add(opisStanu);
        public void AddOpisStanu(Katalog katalog, double cena, int jakosc) => DataContext.opisyStanu.Add(new OpisStanu(katalog, cena, jakosc));

        public OpisStanu GetOpisStanu(int id) => DataContext.opisyStanu[id];

        public IEnumerable<OpisStanu> GetAllOpisStanu() => DataContext.opisyStanu;

        public void UpdateOpisStanu(OpisStanu opisStanu, int id) => DataContext.opisyStanu[id] = opisStanu;

        public void DeleteOpisStanu(OpisStanu opisStanu) => DataContext.opisyStanu.Remove(opisStanu);

        public OpisStanu FindOpisStanu(Katalog katalog, int jakosc)
        {
            return DataContext.opisyStanu.Find(opisStanu => opisStanu.Katalog == katalog && opisStanu.Jakosc == jakosc);
        }
        #endregion
    }
}
