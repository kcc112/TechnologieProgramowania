using System;
using Zadanie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        #endregion
    }
}

