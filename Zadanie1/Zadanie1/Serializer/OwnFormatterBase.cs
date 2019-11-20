﻿using System; 
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Zadanie1.Serializer
{
    public class OwnFormatterBase
    {
        public static void Serialize(DataContext dataContext, Stream stream)
        {
            string fileContent = "";
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();

            foreach (Wykaz wykaz in dataContext.wykazy)
            {
                fileContent += wykaz.Serialize(idGenerator) + "\n";
            }

            foreach (Katalog katalog in dataContext.katalogi.Values)
            {
                fileContent += katalog.Serialize(idGenerator) + "\n";
            }

            foreach (OpisStanu opisStanu in dataContext.opisyStanu)
            {
                fileContent += opisStanu.Serialize(idGenerator) + "\n";
            }

            foreach (Zdarzenie zdarzenie in dataContext.zdarzenia)
            {
                fileContent += zdarzenie.Serialize(idGenerator) + "\n";
            }

            byte[] content = Encoding.ASCII.GetBytes(fileContent);

            stream.Write(content, 0, content.Length);
        }

        public static void Deserialize(DataContext dataContext, Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string fileContent = reader.ReadToEnd();

            List<string> dataList = fileContent.Split('\n').ToList();
            Dictionary<string, Katalog> helperKatalog = new Dictionary<string, Katalog>();
            Dictionary<string, Wykaz> helperWykaz = new Dictionary<string, Wykaz>();
            Dictionary<string, OpisStanu> helperOpisStanu = new Dictionary<string, OpisStanu>();

            for (int i = 0; i < dataList.Count; i++)
            {
                List<string> entity = dataList[i].Split('|').ToList();
                Type type = Type.GetType(entity[0]);

                if (type != null)
                {

                    object obj = Activator.CreateInstance(type);


                    switch (type.ToString())
                    {
                        case "Zadanie1.Wykaz":
                            Wykaz wykaz = (Wykaz)obj;
                            wykaz.Deserialize(entity);
                            dataContext.wykazy.Add(wykaz);
                            helperWykaz.Add(entity[3], wykaz);
                            break;

                        case "Zadanie1.Katalog":
                            Katalog katalog = (Katalog)obj;
                            katalog.Deserialize(entity);
                            dataContext.katalogi.Add(katalog.Id, katalog);
                            helperKatalog.Add(entity[5], katalog);
                            break;

                        case "Zadanie1.OpisStanu":
                            OpisStanu opisStanu = (OpisStanu)obj;
                            opisStanu.Deserialize(entity, helperKatalog);
                            dataContext.opisyStanu.Add(opisStanu);
                            helperOpisStanu.Add(entity[4], opisStanu);
                            break;

                        case "Zadanie1.ZdarzenieDodanie":
                            Zdarzenie zdarzenieDodanie = (ZdarzenieDodanie)obj;
                            zdarzenieDodanie.Deserialize(entity, helperOpisStanu, helperWykaz);
                            dataContext.zdarzenia.Add(zdarzenieDodanie);
                            break;

                        case "Zadanie1.ZdarzenieKupno":
                            Zdarzenie zdarzenieKupno = (ZdarzenieKupno)obj;
                            zdarzenieKupno.Deserialize(entity, helperOpisStanu, helperWykaz);
                            dataContext.zdarzenia.Add(zdarzenieKupno);
                            break;

                    }


                }
            }
        }

    }
}