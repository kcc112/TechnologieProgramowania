﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Testy")]

namespace Zadanie1
{
    public class DataContext
    {
        public List<Wykaz> wykazy = new List<Wykaz>();
        public Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> opisyStanu = new List<OpisStanu>();
    }
}
