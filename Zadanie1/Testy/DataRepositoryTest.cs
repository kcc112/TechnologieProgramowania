using System;
using Zadanie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void TestAddKatalog()
        {
            Katalog k = new Katalog("Pan Tadeusz",
                                    "To spisana trzynastozgloskowcem, zawarta w dwunastu ksiegach opowiesc o szlachcie polskiej poczatku XIX wieku.",
                                    "Adam Mickiewicz");

            DataContext dc = new DataContext();
            DataRepository dr = new DataRepository(dc);
            dr.AddKatalog(k, 1);

            Assert.AreEqual(k, dr.GetKatalog(1));
            Assert.AreEqual(k, dr.GetAllKatalog()[1]);
        }
    }
}

