using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie1
{
    public abstract class Zdarzenie
    {
        public Wykaz Wykaz { get; set; }
        public OpisStanu OpisStanu { get; set; }
        public DateTime Data { get; set; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime data)
        {
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            Data = data;
        }

        public Zdarzenie() { }

        public override string ToString()
        {
            return $"Data: { Data } | " + Wykaz.ToString() + OpisStanu.ToString();
        }

        public virtual string Serialize(ObjectIDGenerator idGenerator)
        {
            string data = "";
            data += GetType().FullName + "|";
            data += idGenerator.GetId(Wykaz, out bool firstTime) + "|";
            data += idGenerator.GetId(OpisStanu, out firstTime) + "|";
            data += Data.ToString() + "|";
            data += idGenerator.GetId(this, out firstTime) + "|";
            return data;
        }

        public virtual void Deserialize(List<string> data, Dictionary<string, OpisStanu> helperOpisStanu, Dictionary<string, Wykaz> helperWykaz)
        {
            Wykaz = helperWykaz[data[1]];
            OpisStanu = helperOpisStanu[data[2]];
            Data = Convert.ToDateTime(data[3]);
        } 

    }
}