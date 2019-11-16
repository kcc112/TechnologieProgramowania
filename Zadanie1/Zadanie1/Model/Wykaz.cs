using System;
using System.Collections.Generic;
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

        public Wykaz() {}

        public override string ToString()
        {
            return $"Imie: { Imie } | Nazwisko: { Nazwisko }";
        }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + ",";
            data += Imie + ",";
            data += Nazwisko + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            return data;
        }

        public virtual void Deserialize(List<string> data)
        {
           Imie = data[1];
           Nazwisko = data[2];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", GetType().FullName);
            info.AddValue("Imie", Imie);
            info.AddValue("Nazwisko", Nazwisko);
        }

        public Wykaz(SerializationInfo info, StreamingContext context)
        {
            Imie = info.GetString("Imie");
            Nazwisko = info.GetString("Nazwisko");
        }
    }
}
