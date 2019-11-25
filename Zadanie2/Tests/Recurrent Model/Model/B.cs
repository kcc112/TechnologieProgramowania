using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    [Serializable]
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


        public string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + "|";
            data += ClassName + "|";
            data += idGenerator.GetId(ClassC, out bool firstTime) + "|";
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
            info.AddValue("refC", ClassC);
        }

        public B(SerializationInfo info, StreamingContext context)
        {
            ClassName = info.GetString("ClassName");
            ClassC = (C)info.GetValue("refC", typeof(C));
        }
    }
}
