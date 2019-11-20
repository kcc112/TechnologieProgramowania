using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    public class C
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
    }
}
