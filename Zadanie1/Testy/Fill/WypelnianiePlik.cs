using System;
using Zadanie1;

namespace Testy
{
    public class WypelnianiePlik : IDataFill
    {
        public void Fill(DataContext context)
        {
            string line;
            int count = 0;

            System.IO.StreamReader katalogi = new System.IO.StreamReader(@"Data/katalogi.txt");
            while ((line = katalogi.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                context.katalogi.Add(count, new Katalog(data[0], data[1], data[2], count));
                count++;
            }
            katalogi.Close();

            System.IO.StreamReader opisyStanu = new System.IO.StreamReader(@"Data/opisyStanu.txt");
            while ((line = opisyStanu.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                context.opisyStanu.Add(new OpisStanu(context.katalogi[int.Parse(data[0])], double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture), int.Parse(data[2])));
            }
            opisyStanu.Close();

            System.IO.StreamReader wykazy = new System.IO.StreamReader(@"Data/wykazy.txt");
            while ((line = wykazy.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                context.wykazy.Add(new Wykaz(data[0], data[1]));
            }
            wykazy.Close();

            System.IO.StreamReader zdarzeniaDodania = new System.IO.StreamReader(@"Data/zdarzeniaDodania.txt");
            while ((line = zdarzeniaDodania.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                context.zdarzenia.Add(new ZdarzenieDodanie(context.wykazy[int.Parse(data[0])], context.opisyStanu[int.Parse(data[1])], new DateTime(int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]))));
            }
            zdarzeniaDodania.Close();

            System.IO.StreamReader zdarzeniaKupna = new System.IO.StreamReader(@"Data/zdarzeniaKupna.txt");
            while ((line = zdarzeniaKupna.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                context.zdarzenia.Add(new ZdarzenieKupno(context.wykazy[int.Parse(data[0])], context.opisyStanu[int.Parse(data[1])], new DateTime(int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]))));
            }
            zdarzeniaKupna.Close();
        }
    }
}
