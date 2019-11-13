using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1.Serializer
{
    public class OwnSerializer
    {
        public static void Serialize(DataContext dataContext, string filename)
        {
            string data = "";
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();

            foreach (Wykaz wykaz in dataContext.wykazy)
            {
                data += wykaz.Serialize(idGenerator) + "\n";
            }

            foreach (Katalog katalog in dataContext.katalogi.Values)
            {
                data += katalog.Serialize(idGenerator) + "\n";
            }

            foreach (OpisStanu opisStanu in dataContext.opisyStanu)
            {
                data += opisStanu.Serialize(idGenerator) + "\n";
            }

            System.IO.File.WriteAllText(filename, data);
        }

        public static void Deserialize(DataContext dataContext, string filename)
        {
            string data = System.IO.File.ReadAllText(filename);
            List<string> dataList = data.Split('\n').ToList();
            Dictionary<string, Katalog> helperKatalog = new Dictionary<string, Katalog>();

            for (int i = 0; i < dataList.Count; i++)
            {
                List<string> entity = dataList[i].Split(',').ToList();
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
                            break;
                    }


                }
            }
        }

    }
}
