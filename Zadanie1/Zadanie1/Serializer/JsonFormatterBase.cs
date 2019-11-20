using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Zadanie1.Serializer
{
    public class JsonFormatterBase
    {
        public static void Serialize(DataContext dataContext, Stream stream)
        {
            string json = JsonConvert.SerializeObject(dataContext, Formatting.Indented);

            byte[] content = Encoding.ASCII.GetBytes(json);
            stream.Write(content, 0, content.Length);
        }

        public static void Deserialize(ref DataContext dataContext, Stream stream)
        {
            JsonConverter[] converters = { new DataContextConverter() };
            StreamReader reader = new StreamReader(stream);

            string fileContent = reader.ReadToEnd();
            dataContext = JsonConvert.DeserializeObject<DataContext>(fileContent, new JsonSerializerSettings() { Converters = converters });
        }
    }
}