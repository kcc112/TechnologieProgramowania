using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Recurrent_Model
{
    [Serializable]
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


        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + ",";
            data += ClassName + ",";
            data += idGenerator.GetId(ClassC, out bool firstTime) + ",";
            data += idGenerator.GetId(this, out firstTime) + ",";
            return data;
        }

        public virtual void Deserialize(List<string> data)
        {
            ClassName = data[1];
        }
    }
}
