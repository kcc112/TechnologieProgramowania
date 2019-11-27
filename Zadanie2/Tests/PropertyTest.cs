using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Recurrent_Model;
using Zadanie2;

namespace Tests
{
    [TestClass]
    public class PropertyTest
    {
        [TestMethod]
        public void TestJsonProperty()
        {
            C ouputC = new C(null, "KlasaC", 6.4f);
            A a = new A(null, "KlasaA", 2.1);
            B b = new B(null, "KlasaB", new DateTime(2017, 10, 1));
            C c = new C(null, "KlasaC", 5.4f);

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

            A a2 = ouputC.ClassA;
            B b2 = a2.ClassB;

            Assert.AreEqual(a2.ExampleDouble, 2.1);

            Assert.AreEqual(b2.ClassName, "KlasaB");
            Assert.AreEqual(b2.ExampleDateTime, new DateTime(2017, 10, 1));

            Assert.AreEqual(ouputC.ClassName, "KlasaC");
            Assert.AreEqual(ouputC.ExampleFloat, 5.4f);
        }

        [TestMethod]
        public void TestCorrectFormatterProperty()
        {
            C ouputC = new C(null, "KlasaC", 6.4f);
            A a = new A(null, "KlasaA", 2.1);
            B b = new B(null, "KlasaB", new DateTime(2017, 10, 1));
            C c = new C(null, "KlasaC", 5.4f);

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
            Assert.AreEqual(ouputC.ExampleFloat, 5.4f);

            A a2 = ouputC.ClassA;
            Assert.AreEqual(a.ClassName, a2.ClassName);
            Assert.AreEqual(a2.ExampleDouble, 2.1);

            B b2 = a2.ClassB;
            Assert.AreEqual(b.ClassName, b2.ClassName);
            Assert.AreEqual(b.ExampleDateTime, b2.ExampleDateTime);
        }
    }
}
