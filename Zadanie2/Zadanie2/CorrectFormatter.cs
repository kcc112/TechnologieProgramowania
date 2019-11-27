using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.Globalization;

namespace Zadanie2
{
    public class CorrectFormatter : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ObjectIDGenerator IdGenerator { get; set; }

        public CorrectFormatter()
        {
            IdGenerator = new ObjectIDGenerator();
        }

        public override object Deserialize(Stream serializationStream)
        {
            List<object> deserializedObjects = new List<object>();
            List<Type> types = new List<Type>();

            StreamReader reader = new StreamReader(serializationStream);
            string fileContent = reader.ReadToEnd();
            List<string> dataList = fileContent.Split('\n').ToList();
            StreamingContext context = new StreamingContext(StreamingContextStates.File);

            for (int i = 0; i < dataList.Count - 1; i++)
            {
                List<string> entity = dataList[i].Split('|').ToList();
                SerializationInfo info = new SerializationInfo(Type.GetType(entity[3] + ", " + entity[3].Split('.').ToList()[0]), new FormatterConverter());
                for (int j = 4; j < entity.Count - 3; j++)
                {
                    info.AddValue(entity[j], entity[j + 1]);
                }
                info.AddValue(entity[entity.Count - 2], null);
                deserializedObjects.Add(Activator.CreateInstance(Type.GetType(entity[3] + ", " + entity[3].Split('.').ToList()[0]), info, context));
                types.Add(deserializedObjects[i].GetType());

            }

            for (int i = 0; i < deserializedObjects.Count - 1; i++)
            {
                foreach (PropertyInfo propertyInfo in deserializedObjects[i].GetType().GetProperties())
                {
                    if (propertyInfo.PropertyType == deserializedObjects[i + 1].GetType())
                    {
                        propertyInfo.SetValue(deserializedObjects[i], deserializedObjects[i + 1]);
                    }
                }
            }

           
            foreach (PropertyInfo propertyInfo in deserializedObjects[deserializedObjects.Count - 1].GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == deserializedObjects[0].GetType())
                {
                    propertyInfo.SetValue(deserializedObjects[deserializedObjects.Count - 1], deserializedObjects[0]);
                }
            }

            return deserializedObjects[0];
        }

        private string FileContent = "";
        bool FirtsTime;

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                info.AddValue("id", IdGenerator.GetId(graph, out FirtsTime));
                info.AddValue("ClassType", graph.GetType().FullName);
                StreamingContext context = new StreamingContext(StreamingContextStates.File);
                data.GetObjectData(info, context);
                foreach (SerializationEntry item in info)
                {
                    if (item.Value is ISerializable && item.Value != null && item.Value.GetType() != typeof(DateTime))
                    {
                        WriteMember(item.Name, item.Value);
                        if (FirtsTime == true)
                        {
                            Serialize(serializationStream, item.Value);
                        }
                    }
                    else
                    {
                        WriteMember(item.Name, item.Value);
                    }
                }
                byte[] content = Encoding.UTF8.GetBytes(FileContent);
                serializationStream.Write(content, 0, content.Length);
                FileContent = "";
            }
            else
            {
                throw new ArgumentException("Implementation of is mandatory");
            }
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            FileContent += name + "|" + val.ToString("d", DateTimeFormatInfo.InvariantInfo) + "|";
        }

        protected override void WriteDouble(double val, string name)
        {
            FileContent += name + "|" + val.ToString("G", CultureInfo.InvariantCulture) + "|";
        }

        protected void WriteString(object str, string name)
        {
            FileContent += name + "|" + (string)str + "|";
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(string)))
            {
                WriteString(obj, name);
            }
            else
            {
                FileContent += name + "|" + IdGenerator.GetId(obj, out FirtsTime) + "\n";
            }
        }

        protected override void WriteInt64(long val, string name)
        {
            FileContent += name + "|" + val.ToString() + "|";
        }

        protected override void WriteSingle(float val, string name)
        {
            FileContent += name + "|" + val.ToString("0.00", CultureInfo.InvariantCulture) + "|";
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}
