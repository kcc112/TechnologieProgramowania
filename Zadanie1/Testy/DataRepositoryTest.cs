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
        #endregion
    }
}

