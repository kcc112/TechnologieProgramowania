using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    [Serializable]
    public class A : ISerializable
    {
        public B ClassB { get; set; }
        public string ClassName { get; set; }
        public double ExampleDouble { get; set; }

        public A(B classB, string className, double exampleDouble)
        {
            ClassB = classB;
            ClassName = className;
            ExampleDouble = exampleDouble;
        }

        public A() { }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + "|";
            data += ClassName + "|";
            data += idGenerator.GetId(ClassB, out bool firstTime) + "|";
            data += idGenerator.GetId(this, out firstTime) + "|";
            return data;
        }

        public void Deserialize(List<string> data)
        {
            ClassName = data[1];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ExampleDouble", ExampleDouble);
            info.AddValue("ClassName", ClassName);
            info.AddValue("refB", ClassB);
        }

        public A(SerializationInfo info, StreamingContext context)
        {
            ClassName = info.GetString("ClassName");
            ExampleDouble = info.GetDouble("ExampleDouble");
            ClassB = (B)info.GetValue("refB", typeof(B));
        }
    }
}
