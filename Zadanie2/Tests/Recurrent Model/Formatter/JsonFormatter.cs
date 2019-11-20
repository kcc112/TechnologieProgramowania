using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Tests.Recurrent_Model
{
    class JsonFormatter
    {
        public static void Serialize(NewContext newContext, Stream stream)
        {
            string json = JsonConvert.SerializeObject(newContext, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            byte[] content = Encoding.ASCII.GetBytes(json);
            stream.Write(content, 0, content.Length);
        }

        public static void Deserialize(ref NewContext newContext, Stream stream)
        {
            StreamReader reader = new StreamReader(stream);

            string fileContent = reader.ReadToEnd();
            newContext = JsonConvert.DeserializeObject<NewContext>(fileContent);
        }
    }
}