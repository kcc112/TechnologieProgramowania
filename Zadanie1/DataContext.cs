using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class DataContext
    {
        public List<Wykaz> wykazy = new List<Wykaz>();
        public Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> opisyStanu = new List<OpisStanu>();

        void dodaj(List<Wykaz> wykazy, Dictionary<int, Katalog> katalogi, ObservableCollection<Zdarzenie> zdarzenia, List<OpisStanu> opisyStanu)
        {
            this.wykazy = wykazy.ToList();
            this.katalogi = katalogi.ToList();
            this.zdarzenia = zdarzenia.ToList();
            this.opisyStanu = opisyStanu.ToList();
        }
    }
}
