using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleToDoList
{
    class BinPersister : IPersister
    {
        private static string BINFilename = ConfigurationManager.AppSettings["BINFilename"];

        public void Write(List<Entry> list)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(BINFilename, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, list);
            stream.Close();
        }

        public List<Entry> Read()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(BINFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Entry> list = (List<Entry>) formatter.Deserialize(stream);
            stream.Close();

            Debug.WriteLine("Liczba odczytanych elementów: {0}", list.Count);

            return list;
        }

    }
}
