using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public interface IDataRepository
    {
        void AddKatalog(Katalog katalog, int id);
        void AddWykaz(Wykaz wykaz);
        void AddOpisStanu(OpisStanu opisStanu);
        void AddZdarzenie(Zdarzenie zdarzenie);

        Katalog GetKatalog(int id);
        Wykaz GetWykaz(int id);
        OpisStanu GetOpisStanu(int id);
        Zdarzenie GetZdarzenie(int id);

        IEnumerable<Katalog> GetAllKatalog();
        IEnumerable<Wykaz> GetAllWykaz();
        IEnumerable<OpisStanu> GetAllOpisStanu();
        IEnumerable<Zdarzenie> GetAllZdarzenie();

        void UpdateKatalog(Katalog katalog, int id);
        void UpdateWykaz(Wykaz wykaz, int id);
        void UpdateOpisStanu(OpisStanu opisStanu, int id);
        void UpdateZdarzenie(Zdarzenie zdarzenie, int id);


        void DeleteKatalog(int id);
        void DeleteWykaz(Wykaz wykaz);
        void DeleteOpisStanu(OpisStanu opisStanu);
        void DeleteZdarzenie(Zdarzenie zdarzenie);

        //Potrzebne do działania logiki
        OpisStanu FindOpisStanu(Katalog katalog, int jakosc);
        void AddKatalog(string tytul, string opis, string autor, int id);
        void AddOpisStanu(Katalog katalog, double cena, int jakosc);
        void ZdarzenieKupno(OpisStanu opisStanu, Wykaz wykaz, DateTime date);
        void AddWykaz(string imie, string nazwisko);
    }
}
