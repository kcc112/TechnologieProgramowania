using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    [Serializable]
    [JsonObject]
    public class C : ISerializable
    {
        public A ClassA { get; set; }
        public string ClassName { get; set; }
        public float ExampleFloat { get; set; }

        public C(A classA, string className, float exampleFloat)
        {
            ClassA = classA;
            ClassName = className;
            ExampleFloat = exampleFloat;
        }

        public C() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ExampleFloat", ExampleFloat);
            info.AddValue("ClassName", ClassName);
            info.AddValue("refA", ClassA);
        }

        public C(SerializationInfo info, StreamingContext context)
        {
            ClassName = info.GetString("ClassName");
            ClassA = (A)info.GetValue("refA", typeof(A));
            ExampleFloat = info.GetSingle("ExampleFloat");
        }
    }
}
