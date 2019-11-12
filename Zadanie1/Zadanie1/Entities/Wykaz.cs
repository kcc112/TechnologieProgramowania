using System.Runtime.Serialization;

namespace Zadanie1
{
    public class Wykaz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public Wykaz(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }

        public override string ToString()
        {
            return $"Imie: { Imie } | Nazwisko: { Nazwisko }";
        }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += this.GetType().FullName + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            data += this.Imie + ",";
            data += this.Nazwisko + ",";
            return data;
        }
    }
}
