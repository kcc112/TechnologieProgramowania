using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie1
{
    public class OpisStanu
    {
        public Katalog Katalog { get; set; }
        public double Cena { get; set; }
        public int Jakosc { get; set; }

        public OpisStanu(Katalog katalog, double cena, int jakosc)
        {
            Katalog = katalog;
            Cena = cena;
            Jakosc = jakosc;
        }

        public OpisStanu() { }

        public override string ToString()
        {
            return $"Cena: { Cena } | Jakosc: { Jakosc } | " + Katalog.ToString();
        }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + ",";
            data += idGenerator.GetId(Katalog, out bool firstTine) + ",";
            data += Cena + ",";
            data += Jakosc + ",";
            data += idGenerator.GetId(this, out bool firstTime) + ",";
            return data;
        }

        public virtual void Deserialize(List<string> data, Dictionary<string, Katalog> helperKatalog)
        {
            Katalog = helperKatalog[data[1]];
            Cena = double.Parse(data[2]);
            Jakosc = int.Parse(data[3]);
        }
    }
}
