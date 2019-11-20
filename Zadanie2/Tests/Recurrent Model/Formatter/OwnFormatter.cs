using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Tests.Recurrent_Model;

namespace Tests
{
    public class OwnFormatter
    {
        public static void Serialize(NewContext newContext, Stream stream)
        {
            string fileContent = "";
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();

            foreach (A a in newContext.a)
            {
                fileContent += a.Serialize(idGenerator) + "\n";
            }

            foreach (B b in newContext.b)
            {
                fileContent += b.Serialize(idGenerator) + "\n";
            }

            foreach (C c in newContext.c)
            {
                fileContent += c.Serialize(idGenerator) + "\n";
            }

            byte[] content = Encoding.UTF8.GetBytes(fileContent);

            stream.Write(content, 0, content.Length);
        }

        public static void Deserialize(NewContext newContext, Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string fileContent = reader.ReadToEnd();

            List<string> dataList = fileContent.Split('\n').ToList();

            Dictionary<string, A> helperAId = new Dictionary<string, A>();
            Dictionary<string, B> helperBId = new Dictionary<string, B>();
            Dictionary<string, C> helperCId = new Dictionary<string, C>();

            Dictionary<string, A> helperARef = new Dictionary<string, A>();
            Dictionary<string, B> helperBRef = new Dictionary<string, B>();
            Dictionary<string, C> helperCRef = new Dictionary<string, C>();

            for (int i = 0; i < dataList.Count; i++)
            {
                List<string> entity = dataList[i].Split('|').ToList();
                Type type = Type.GetType(entity[0]);

                if (type != null)
                {

                    object obj = Activator.CreateInstance(type);


                    switch (type.ToString())
                    {
                        case "Tests.Recurrent_Model.A":
                            A a = (A)obj;
                            a.Deserialize(entity);
                            newContext.a.Add(a);
                            helperAId.Add(entity[3], a);
                            helperARef.Add(entity[2], a);
                            break;

                        case "Tests.Recurrent_Model.B":
                            B b = (B)obj;
                            b.Deserialize(entity);
                            newContext.b.Add(b);
                            helperBId.Add(entity[3], b);
                            helperBRef.Add(entity[2], b);
                            break;

                        case "Tests.Recurrent_Model.C":
                            C c = (C)obj;
                            c.Deserialize(entity);
                            newContext.c.Add(c);
                            helperCId.Add(entity[3], c);
                            helperCRef.Add(entity[2], c);
                            break;
                    }
                }
            }

            for (int i = 1; i <= dataList.Count; i++)
            {
                if (helperARef.TryGetValue(i.ToString(), out A a) == true)
                {
                    helperARef[i.ToString()].ClassB = helperBId[i.ToString()];
                }

                if (helperBRef.TryGetValue(i.ToString(), out B b) == true)
                {
                    helperBRef[i.ToString()].ClassC = helperCId[i.ToString()];
                }

                if (helperCRef.TryGetValue(i.ToString(), out C c) == true)
                {
                    helperCRef[i.ToString()].ClassA = helperAId[i.ToString()];
                }
            }
        }
    }
}
