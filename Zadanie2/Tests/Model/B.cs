using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    [Serializable]
    [JsonObject]
    public class B : ISerializable
    {
        public C ClassC { get; set; }
        public string ClassName { get; set; }
        public DateTime ExampleDateTime { get; set; }

        public B(C classC, string className, DateTime exampleDateTime)
        {
            ClassC = classC;
            ClassName = className;
            ExampleDateTime = exampleDateTime;
        }

        public B() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ExampleDateTime", ExampleDateTime);
            info.AddValue("ClassName", ClassName);
            info.AddValue("refC", ClassC);
        }

        public B(SerializationInfo info, StreamingContext context)
        {
            ClassName = info.GetString("ClassName");
            ClassC = (C)info.GetValue("refC", typeof(C));
            ExampleDateTime = info.GetDateTime("ExampleDateTime");
        }
    }
}
