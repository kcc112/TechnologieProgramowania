﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.Recurrent_Model
{
    public class B
    {
        public C ClassC { get; set; }
        public string ClassName { get; set; }

        public B(C classB, string className)
        {
            ClassC = classB;
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
    }
}
