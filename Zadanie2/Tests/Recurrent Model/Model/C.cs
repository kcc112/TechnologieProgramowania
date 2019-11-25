using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    [Serializable]
    public class C : ISerializable
    {
        public A ClassA { get; set; }
        public string ClassName { get; set; }

        public C(A classA, string className)
        {
            ClassA = classA;
            ClassName = className;
        }

        public C() { }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + "|";
            data += ClassName + "|";
            data += idGenerator.GetId(ClassA, out bool firstTime) + "|";
            data += idGenerator.GetId(this, out firstTime) + "|";
            return data;
        }

        public void Deserialize(List<string> data)
        {
            ClassName = data[1];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("refA", ClassA);
        }

        public C(SerializationInfo info, StreamingContext context)
        {
            ClassName = info.GetString("ClassName");
            ClassA = (A)info.GetValue("refA", typeof(A));
        }
    }
}
