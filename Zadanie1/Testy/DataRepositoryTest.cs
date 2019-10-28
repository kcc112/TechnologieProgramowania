using System;
using Zadanie1;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Testy
{
    [TestClass]
    public class DataRepositoryTest
    {
        #region Katalog Test
        [TestMethod]
        public void Test_Add_Katalog()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            dataRepository.AddKatalog(katalog, 1);
            Assert.AreEqual(1, dataRepository.DataContext.katalogi.Count);
        }

        [TestMethod]
        public void Test_Get_Katalog()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            dataRepository.AddKatalog(katalog, 1);
            Assert.AreEqual(katalog, dataRepository.GetKatalog(1));
        }

        [TestMethod]
        public void Test_Get_All_Katalog()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            dataRepository.AddKatalog(katalog, 1);
            IEnumerable<Katalog> katalogi = dataRepository.GetAllKatalog();
            Assert.AreEqual(1, katalogi.ToList<Katalog>().Count);
        }

        [TestMethod]
        public void Test_Update_Katalog()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog1 = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            dataRepository.AddKatalog(katalog1, 1);
            Katalog katalog2 = new Katalog("Pan Mariusz", "opis", "Mariusz Mickiewicz", 1);
            dataRepository.UpdateKatalog(katalog2, 1);
            Assert.AreEqual(katalog2, dataRepository.GetKatalog(1));
        }

        [TestMethod]
        public void Test_Delete_Katalog()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            dataRepository.AddKatalog(katalog, 1);
            dataRepository.DeleteKatalog(1);
            Assert.AreEqual(0, dataRepository.DataContext.katalogi.Count);
        }
        #endregion

        #region Wykaz Test
        [TestMethod]
        public void Test_Add_Wykaz()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataRepository.AddWykaz(wykaz);
            Assert.AreEqual(1, dataRepository.DataContext.wykazy.Count);
        }

        [TestMethod]
        public void Test_Get_Wykaz()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataRepository.AddWykaz(wykaz);
            Assert.AreEqual(wykaz, dataRepository.GetWykaz(0));
        }

        [TestMethod]
        public void Test_Get_All_Wykaz()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataRepository.AddWykaz(wykaz);
            IEnumerable<Wykaz> wykazy = dataRepository.GetAllWykaz();
            Assert.AreEqual(1, wykazy.ToList<Wykaz>().Count);
        }

        [TestMethod]
        public void Test_Update_Wykaz()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Wykaz wykaz1 = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataRepository.AddWykaz(wykaz1);
            Wykaz wykaz2 = new Wykaz("Pan Mariusz", "Mariusz Mickiewicz");
            dataRepository.UpdateWykaz(wykaz2, 0);
            Assert.AreEqual(wykaz2, dataRepository.GetWykaz(0));
        }

        [TestMethod]
        public void Test_Delete_Wykaz()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataRepository.AddWykaz(wykaz);
            dataRepository.DeleteWykaz(wykaz);
            Assert.AreEqual(0, dataRepository.DataContext.wykazy.Count);
        }
        #endregion

        #region OpisStanu Test
        [TestMethod]
        public void Test_Add_OpisStanu()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            dataRepository.AddOpisStanu(opisStanu);
            Assert.AreEqual(1, dataRepository.DataContext.opisyStanu.Count);
        }

        [TestMethod]
        public void Test_Get_OpisStanu()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            dataRepository.AddOpisStanu(opisStanu);
            Assert.AreEqual(opisStanu, dataRepository.GetOpisStanu(0));
        }

        [TestMethod]
        public void Test_Get_All_OpisStanu()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            dataRepository.AddOpisStanu(opisStanu);
            IEnumerable<OpisStanu> opisyStanu = dataRepository.GetAllOpisStanu();
            Assert.AreEqual(1, opisyStanu.ToList<OpisStanu>().Count);
        }

        [TestMethod]
        public void Test_Update_OpisStanu()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog1 = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            Katalog katalog2 = new Katalog("Pan Mariusz", "opis", "Mariusz Mickiewicz", 2);
            OpisStanu opisStanu1 = new OpisStanu(katalog1, 10, 2);
            dataRepository.AddOpisStanu(opisStanu1);
            OpisStanu opisStanu2 = new OpisStanu(katalog2, 10, 2);
            dataRepository.UpdateOpisStanu(opisStanu2, 0);
            Assert.AreEqual(opisStanu2, dataRepository.GetOpisStanu(0));
        }

        [TestMethod]
        public void Test_Delete_OpisStanu()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            dataRepository.DeleteOpisStanu(opisStanu);
            Assert.AreEqual(0, dataRepository.DataContext.opisyStanu.Count);
        }
        #endregion

        #region Zdarzenie
        public void Test_Add_Zdarzenie()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            DateTime date = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie = new ZdarzenieDodanie(wykaz, opisStanu, date);
            dataRepository.AddZdarzenie(zdarzenie);
            Assert.AreEqual(1, dataRepository.DataContext.zdarzenia.Count);
        }

        [TestMethod]
        public void Test_Get_Zdarzenie()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            DateTime date = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie = new ZdarzenieDodanie(wykaz, opisStanu, date);
            dataRepository.AddZdarzenie(zdarzenie);
            Assert.AreEqual(zdarzenie, dataRepository.GetZdarzenie(0));
        }

        [TestMethod]
        public void Test_Get_All_Zdarzenie()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            DateTime date = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie = new ZdarzenieDodanie(wykaz, opisStanu, date);
            dataRepository.AddZdarzenie(zdarzenie);
            IEnumerable<Zdarzenie> zdarzenia = dataRepository.GetAllZdarzenie();
            Assert.AreEqual(1, zdarzenia.ToList<Zdarzenie>().Count);
        }

        [TestMethod]
        public void Test_Update_Zdarzenuie()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog1 = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu1 = new OpisStanu(katalog1, 10, 2);
            Wykaz wykaz1 = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            DateTime date1 = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie1 = new ZdarzenieDodanie(wykaz1, opisStanu1, date1);
            Katalog katalog2 = new Katalog("Pan Mariusz", "opis", "Mariusz Mickiewicz", 1);
            OpisStanu opisStanu2 = new OpisStanu(katalog2, 10, 2);
            Wykaz wykaz2 = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            DateTime date2 = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie2 = new ZdarzenieDodanie(wykaz2, opisStanu2, date2);
            dataRepository.AddZdarzenie(zdarzenie1);
            dataRepository.UpdateZdarzenie(zdarzenie2, 0);
            Assert.AreEqual(zdarzenie2, dataRepository.GetZdarzenie(0));
        }

        [TestMethod]
        public void Test_Delete_Zdarzenuie()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            OpisStanu opisStanu = new OpisStanu(katalog, 10, 2);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            DateTime date = new DateTime(2017, 2, 22);
            Zdarzenie zdarzenie = new ZdarzenieDodanie(wykaz, opisStanu, date);
            dataRepository.AddZdarzenie(zdarzenie);
            dataRepository.DeleteZdarzenie(zdarzenie);
            Assert.AreEqual(0, dataRepository.DataContext.zdarzenia.Count);
        }
        #endregion
    }
}

