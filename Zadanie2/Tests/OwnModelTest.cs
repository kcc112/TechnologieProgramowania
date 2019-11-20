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
        public void OwnFormatterTest()
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

            Assert.AreEqual(dataContextToSerialize.katalogi[0].ToString(), dataContextDeserialized.katalogi[0].ToString());
            Assert.AreEqual(dataContextToSerialize.opisyStanu[0].ToString(), dataContextDeserialized.opisyStanu[0].ToString());
            Assert.AreEqual(dataContextToSerialize.wykazy[0].ToString(), dataContextDeserialized.wykazy[0].ToString());
            Assert.AreEqual(dataContextToSerialize.zdarzenia[0].ToString(), dataContextDeserialized.zdarzenia[0].ToString());

            Assert.AreEqual(dataContextToSerialize.katalogi[1].ToString(), dataContextDeserialized.katalogi[1].ToString());
            Assert.AreEqual(dataContextToSerialize.opisyStanu[1].ToString(), dataContextDeserialized.opisyStanu[1].ToString());
            Assert.AreEqual(dataContextToSerialize.wykazy[1].ToString(), dataContextDeserialized.wykazy[1].ToString());
            Assert.AreEqual(dataContextToSerialize.zdarzenia[1].ToString(), dataContextDeserialized.zdarzenia[1].ToString());
        }

        [TestMethod]
        public void JsonFormatterTest()
        {
            DataContext dataContextToSerialize = new DataContext();
            DataContext dataContextDeserialized = new DataContext();

            IDataFill dataFill = new WypelnianieStalymi();
            new DataRepository(dataFill, dataContextToSerialize);

            File.Delete("json_format.json");
            Stream stream = File.Open("json_format.json", FileMode.Create, FileAccess.ReadWrite);
            JsonFormatterBase.Serialize(dataContextToSerialize, stream);
            stream.Close();

            Stream streamDeserialize = File.Open("json_format.json", FileMode.Open, FileAccess.Read);
            JsonFormatterBase.Deserialize(ref dataContextDeserialized, streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(dataContextToSerialize.katalogi[0].ToString(), dataContextDeserialized.katalogi[0].ToString());
            Assert.AreEqual(dataContextToSerialize.opisyStanu[0].ToString(), dataContextDeserialized.opisyStanu[0].ToString());
            Assert.AreEqual(dataContextToSerialize.wykazy[0].ToString(), dataContextDeserialized.wykazy[0].ToString());
            Assert.AreEqual(dataContextToSerialize.zdarzenia[0].ToString(), dataContextDeserialized.zdarzenia[0].ToString());

            Assert.AreEqual(dataContextToSerialize.katalogi[1].ToString(), dataContextDeserialized.katalogi[1].ToString());
            Assert.AreEqual(dataContextToSerialize.opisyStanu[1].ToString(), dataContextDeserialized.opisyStanu[1].ToString());
            Assert.AreEqual(dataContextToSerialize.wykazy[1].ToString(), dataContextDeserialized.wykazy[1].ToString());
            Assert.AreEqual(dataContextToSerialize.zdarzenia[1].ToString(), dataContextDeserialized.zdarzenia[1].ToString());
        }
    }
}
