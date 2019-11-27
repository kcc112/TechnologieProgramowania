using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Recurrent_Model;
using Zadanie2;

namespace Tests
{
    [TestClass]
    public class RecursionTest
    {
        [TestMethod]
        public void TestJsonProperty()
        {
            C ouputC = new C(null, "KlasaC");
            A a = new A(null, "KlasaA", 2.1);
            B b = new B(null, "KlasaB");
            C c = new C(null, "KlasaC");

            a.ClassB = b;
            b.ClassC = c;
            c.ClassA = a;

            string filename = "json_serialization_results_.json";
            File.Delete(filename);
            Stream streamSerialize = File.Open(filename, FileMode.Create, FileAccess.ReadWrite);
            JsonFormatter.Serialize(c, streamSerialize);
            streamSerialize.Close();

            Stream streamDeserialize = File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
            ouputC = JsonFormatter.Deserialize<C>(streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(a.ExampleDouble, 2.1);
            Assert.AreEqual(b.ClassName, "KlasaB");
            Assert.AreEqual(c.ClassName, "KlasaC");
        }

        [TestMethod]
        public void CorrectFormatterTest()
        {
            C ouputC = new C(null, "KlasaC");
            A a = new A(null, "KlasaA", 2.1);
            B b = new B(null, "KlasaB");
            C c = new C(null, "KlasaC");

            a.ClassB = b;
            b.ClassC = c;
            c.ClassA = a;

            string filename = "own_serialization_results.txt";
            CorrectFormatter formatter = new CorrectFormatter();
            File.Delete(filename);
            Stream stream = File.Open(filename, FileMode.Create, FileAccess.ReadWrite);
            formatter.Serialize(stream, c);
            stream.Close();

            Stream streamDeserialize = File.Open(filename, FileMode.Open, FileAccess.Read);
            ouputC = (C)formatter.Deserialize(streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(c.ClassName, ouputC.ClassName);
            A a2 = ouputC.ClassA;
            Assert.AreEqual(a.ClassName, a2.ClassName);
            B b2 = a2.ClassB;
            Assert.AreEqual(b.ClassName, b2.ClassName);

            Assert.AreSame(ouputC.ClassA, a2);
            Assert.AreSame(a2.ClassB, b2);
            Assert.AreSame(b2.ClassC, ouputC);
        }

        [TestMethod]
        public void TestJsonReferences()
        {
            C ouputC = new C(null, "KlasaC");
            A a = new A(null, "KlasaA", 2.1);
            B b = new B(null, "KlasaB");
            C c = new C(null, "KlasaC");

            a.ClassB = b;
            b.ClassC = c;
            c.ClassA = a;

            string filename = "json_serialization_results.json";
            File.Delete(filename);
            Stream streamSerialize = File.Open(filename, FileMode.Create, FileAccess.ReadWrite);
            JsonFormatter.Serialize(c, streamSerialize);
            streamSerialize.Close();


            Stream streamDeserialize = File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
            ouputC = JsonFormatter.Deserialize<C>(streamDeserialize);
            streamDeserialize.Close();

            A a2 = ouputC.ClassA;
            B b2 = a2.ClassB;

            Assert.AreSame(ouputC.ClassA, a2);
            Assert.AreSame(a2.ClassB, b2);
            Assert.AreSame(b2.ClassC, ouputC);
        }
    }
}
