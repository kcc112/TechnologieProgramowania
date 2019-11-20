using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testy;
using Zadanie1;
using Zadanie1.Serializer;

namespace Tests
{
    [TestClass]
    public class OwnModelTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            DataContext dataContextToSerialize = new DataContext();
            DataContext dataContextDeserialized = new DataContext();

            IDataFill dataFill = new WypelnianieStalymi();
            new DataRepository(dataFill, dataContextToSerialize);

            File.Delete("own_format.txt");
            Stream stream = File.Open("own_format.txt", FileMode.Create, FileAccess.ReadWrite);
            OwnFormatterBase.Serialize(dataContextToSerialize, stream);
            stream.Close();

            Stream streamDeserialize = File.Open("own_format.txt", FileMode.Open, FileAccess.Read);
            OwnFormatterBase.Deserialize(dataContextDeserialized, streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(dataContextToSerialize.katalogi.ToString(), dataContextDeserialized.katalogi.ToString());
            Assert.AreEqual(dataContextToSerialize.opisyStanu.ToString(), dataContextDeserialized.opisyStanu.ToString());
            Assert.AreEqual(dataContextToSerialize.wykazy.ToString(), dataContextDeserialized.wykazy.ToString());
            Assert.AreEqual(dataContextToSerialize.zdarzenia.ToString(), dataContextDeserialized.zdarzenia.ToString());
        }
    }
}
