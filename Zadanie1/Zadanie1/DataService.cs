using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class DataService
    {
        private readonly IDataRepository dataRepository;
        public DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public void BuyBook(DateTime date, int katalogId, int jakosc, Wykaz wykaz)
        {
            try
            {
                dataRepository.GetKatalog(katalogId);
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("Error");
            }

            Katalog katalog = dataRepository.GetKatalog(katalogId);
            OpisStanu opisStanu = dataRepository.FindOpisStanu(katalog, jakosc);

            if (opisStanu == null) throw new ArgumentException("Error");

            dataRepository.ZdarzenieKupno(opisStanu, wykaz, date);
            dataRepository.DeleteOpisStanu(opisStanu);
        }

        public void AddBook(string tytul, string opis, string autor, int id)
        {
            try
            {
                dataRepository.GetKatalog(id);
            }
            catch (KeyNotFoundException)
            {
                dataRepository.AddKatalog(tytul, opis, autor, id);
                return;
            }

            throw new ArgumentException($"Error");
        }

        public void AddOpisStanu(Katalog katalog, double cena, int jakosc)
        {
            dataRepository.AddOpisStanu(katalog, cena, jakosc);
        }

    }
}
