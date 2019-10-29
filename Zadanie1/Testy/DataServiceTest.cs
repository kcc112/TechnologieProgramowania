using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie1;

namespace Testy
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void Test_Buy_Book_Add_Zdarzenie()
        {

            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            DateTime date = new DateTime(2017, 2, 22);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataService.BuyBook(date, 0, 1, wykaz);
            Assert.AreEqual(23, dataContest.zdarzenia.Count);
        }

        [TestMethod]
        public void Test_Buy_Book_Delete_Stan()
        {

            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            DateTime date = new DateTime(2017, 2, 22);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataService.BuyBook(date, 0, 1, wykaz);
            Assert.AreEqual(9, dataContest.opisyStanu.Count);
        }

        [TestMethod]
        public void Test_Buy_Book_Event_Handle()
        {
            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            DateTime date = new DateTime(2017, 2, 22);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataService.BuyBook(date, 0, 1, wykaz);
            Assert.AreEqual(1, dataRepository.BookBought);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Buy_Book_Book_Not_Present()
        {
            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            DateTime date = new DateTime(2017, 2, 22);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataService.BuyBook(date, 10, 1, wykaz);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Buy_Book_No_State()
        {
            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            DateTime date = new DateTime(2017, 2, 22);
            Wykaz wykaz = new Wykaz("Pan Tadeusz", "Adam Mickiewicz");
            dataService.BuyBook(date, 0, 100, wykaz);
        }

        [TestMethod]
        public void Test_Add_Book()
        {
            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            dataService.AddBook("Pan Tadeusz", "opis", "Adam Mickiewicz", 4);
            Assert.AreEqual(4, dataContest.katalogi.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Add_Book_Id_Exist()
        {
            IDataFill dataFill = new WypelnianieStalymi();
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataFill, dataContest);
            DataService dataService = new DataService(dataRepository);
            dataService.AddBook("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
        }

        [TestMethod]
        public void Add_OpisStanu()
        {
            DataContext dataContest = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContest);
            Katalog katalog = new Katalog("Pan Tadeusz", "opis", "Adam Mickiewicz", 1);
            dataRepository.AddOpisStanu(katalog, 10, 10);
            Assert.AreEqual(1, dataContest.opisyStanu.Count);
        }
    }
}
