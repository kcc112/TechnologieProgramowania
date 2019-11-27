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

        public C(A classA, string className)
        {
            ClassA = classA;
            ClassName = className;
        }

        public C() { }

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
