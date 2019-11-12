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
        //    string data = "";
        //    ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        //    bool firstTime = false;
        //    foreach (Wykaz wykaz in dataContext.wykazy)
        //    {
        //        data += wykaz.Serialize(idGenerator) + "\n";
        //    }

            System.IO.File.WriteAllText(filename, "XD");
        }

    }
}
