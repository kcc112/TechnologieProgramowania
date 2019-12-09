using System;
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
        public void TestCorrectFormatterReferences()
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
            A a2 = ouputC.ClassA;
            Assert.AreEqual(a.ClassName, a2.ClassName);
            Assert.AreEqual(a.ExampleDouble, a2.ExampleDouble);
            B b2 = a2.ClassB;
            Assert.AreEqual(b.ExampleDateTime, b2.ExampleDateTime);
            Assert.AreEqual(b.ClassName, b2.ClassName);

            Assert.AreSame(ouputC.ClassA, a2);
            Assert.AreSame(a2.ClassB, b2);
            Assert.AreSame(b2.ClassC, ouputC);
        }

        [TestMethod]
        public void TestJsonReferences()
        {
            C ouputC = new C(null, "KlasaC", 6.4f);
            A a = new A(null, "KlasaA", 2.1);
            B b = new B(null, "KlasaB", new DateTime(2017, 10, 1));
            C c = new C(null, "KlasaC", 5.4f);

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

            Assert.AreSame(newContextToDerialize.a[0].ClassB, newContextToDerialize.b[0]);
            Assert.AreSame(newContextToDerialize.b[0].ClassC, newContextToDerialize.c[0]);
            Assert.AreSame(newContextToDerialize.c[0].ClassA, newContextToDerialize.a[0]);

            Assert.AreSame(newContextToDerialize.a[1].ClassB, newContextToDerialize.b[1]);
            Assert.AreSame(newContextToDerialize.b[1].ClassC, newContextToDerialize.c[1]);
            Assert.AreSame(newContextToDerialize.c[1].ClassA, newContextToDerialize.a[1]);
            Assert.AreSame(newContextToDerialize.c[1].ClassA, newContextToDerialize.a[1]);
        }
    }
}
