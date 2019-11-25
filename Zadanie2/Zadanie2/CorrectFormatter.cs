using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;

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
            }


            Type type1 = deserializedObjects[2].GetType();
            Type type2 = deserializedObjects[1].GetType();
            Type type3 = deserializedObjects[0].GetType();

            PropertyInfo prop1 = type1.GetProperty("ClassA");
            PropertyInfo prop2 = type2.GetProperty("ClassB");
            PropertyInfo prop3 = type3.GetProperty("ClassC");

            prop1.SetValue(deserializedObjects[2], deserializedObjects[1], null);
            prop2.SetValue(deserializedObjects[1], deserializedObjects[0], null);
            prop3.SetValue(deserializedObjects[0], deserializedObjects[2], null);

            return deserializedObjects[2];
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable data = (ISerializable)graph;
            string fileContent = "";
            SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            info.AddValue("id", IdGenerator.GetId(graph, out bool firtsTime));
            info.AddValue("ClassType", graph.GetType().FullName);
            StreamingContext context = new StreamingContext(StreamingContextStates.File);
            data.GetObjectData(info, context);
            foreach (SerializationEntry item in info)
            {

                if (item.Value is ISerializable && item.Value != null)
                {
                    fileContent += item.Name + "|" + IdGenerator.GetId(item.Value, out firtsTime) + "\n";
                    if (firtsTime == true)
                    {
                        Serialize(serializationStream, item.Value);
                    }
                }
                else
                {
                    fileContent += item.Name + "|" + item.Value + "|";
                }
            }
                
            byte[] content = Encoding.UTF8.GetBytes(fileContent);
            serializationStream.Write(content, 0, content.Length);
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

        protected override void WriteDateTime(DateTime val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
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

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
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
