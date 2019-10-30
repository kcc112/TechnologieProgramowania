using Zadanie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass]
    public class DataFillTest
    {
        [TestMethod]
        public void Test_Wypelnianie_Stalymi_Fill()
        {
            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContext = new DataContext();
            new DataRepository(dataFill, dataContext);
            Assert.AreEqual(3, dataContext.katalogi.Count);
            Assert.AreEqual(10, dataContext.opisyStanu.Count);
            Assert.AreEqual(8, dataContext.wykazy.Count);
            Assert.AreEqual(22, dataContext.zdarzenia.Count);
        }

        [TestMethod]
        public void Test_Wypelnianie_Plik_Fill()
        {
            IDataFill dataFill = new WypelnianiePlik();
            DataContext dataContext = new DataContext();
            new DataRepository(dataFill, dataContext);
            Assert.AreEqual(3, dataContext.katalogi.Count);
            Assert.AreEqual(10, dataContext.opisyStanu.Count);
            Assert.AreEqual(8, dataContext.wykazy.Count);
            Assert.AreEqual(22, dataContext.zdarzenia.Count);
        }
    }
}
