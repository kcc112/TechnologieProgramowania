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
    }
}

