using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    [Serializable]
    [JsonObject]
    public class B : ISerializable
    {
        public C ClassC { get; set; }
        public string ClassName { get; set; }

        public B(C classC, string className)
        {
            ClassC = classC;
            ClassName = className;
        }

        public B() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("refC", ClassC);
        }

        public B(SerializationInfo info, StreamingContext context)
        {
            ClassName = info.GetString("ClassName");
            ClassC = (C)info.GetValue("refC", typeof(C));
        }
    }
}
