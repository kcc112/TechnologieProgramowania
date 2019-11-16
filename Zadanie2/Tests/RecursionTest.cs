using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Recurrent_Model;

namespace Tests
{
    [TestClass]
    public class RecursionTest
    {
        [TestMethod]
        public void TestClassName()
        {
            NewContext newContextToSerialize = new NewContext();
            NewContext newContextToDerialize = new NewContext();

            A a = new A();
            B b = new B();
            C c = new C();

            a.ClassB = b;
            b.ClassC = c;
            c.ClassA = a;

            a.ClassName = "A1";
            b.ClassName = "B1";
            c.ClassName = "C1";

            newContextToSerialize.a.Add(a);
            newContextToSerialize.b.Add(b);
            newContextToSerialize.c.Add(c);

            File.Delete("r_test.txt");
            Stream streamSerialize = File.Open("r_test.txt", FileMode.Create, FileAccess.ReadWrite);
            OwnFormatter.Serialize(newContextToSerialize, streamSerialize);
            streamSerialize.Close();

            Stream streamDeserialize = File.Open("r_test.txt", FileMode.Open, FileAccess.ReadWrite);
            OwnFormatter.Deserialize(newContextToDerialize, streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(newContextToSerialize.a[0].ClassName, newContextToDerialize.a[0].ClassName);
            Assert.AreEqual(newContextToSerialize.b[0].ClassName, newContextToDerialize.b[0].ClassName);
            Assert.AreEqual(newContextToSerialize.c[0].ClassName, newContextToDerialize.c[0].ClassName);
        }

        [TestMethod]
        public void TestReferences()
        {
            NewContext newContextToSerialize = new NewContext();
            NewContext newContextToDerialize = new NewContext();

            A a1 = new A();
            B b1 = new B();
            C c1 = new C();

            a1.ClassB = b1;
            b1.ClassC = c1;
            c1.ClassA = a1;

            a1.ClassName = "A1";
            b1.ClassName = "B1";
            c1.ClassName = "C1";

            newContextToSerialize.a.Add(a1);
            newContextToSerialize.b.Add(b1);
            newContextToSerialize.c.Add(c1);


            A a2 = new A();
            B b2 = new B();
            C c2 = new C();

            a2.ClassB = b2;
            b2.ClassC = c2;
            c2.ClassA = a2;

            a2.ClassName = "A1";
            b2.ClassName = "B1";
            c2.ClassName = "C1";

            newContextToSerialize.a.Add(a2);
            newContextToSerialize.b.Add(b2);
            newContextToSerialize.c.Add(c2);


            File.Delete("r_test.txt");
            Stream stream = File.Open("r_test.txt", FileMode.Create, FileAccess.ReadWrite);
            OwnFormatter.Serialize(newContextToSerialize, stream);
            stream.Close();

            Stream streamDeserialize = File.Open("r_test.txt", FileMode.Open, FileAccess.ReadWrite);
            OwnFormatter.Deserialize(newContextToDerialize, streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(newContextToDerialize.a[0].ClassB, newContextToDerialize.b[0]);
            Assert.AreEqual(newContextToDerialize.b[0].ClassC, newContextToDerialize.c[0]);
            Assert.AreEqual(newContextToDerialize.c[0].ClassA, newContextToDerialize.a[0]);

            Assert.AreEqual(newContextToDerialize.a[1].ClassB, newContextToDerialize.b[1]);
            Assert.AreEqual(newContextToDerialize.b[1].ClassC, newContextToDerialize.c[1]);
            Assert.AreEqual(newContextToDerialize.c[1].ClassA, newContextToDerialize.a[1]);
            Assert.AreEqual(newContextToDerialize.c[1].ClassA, newContextToDerialize.a[1]);
        }
    }
}
