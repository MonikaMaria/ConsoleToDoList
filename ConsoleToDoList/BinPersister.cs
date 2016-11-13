using System;
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
            Stream stream = new FileStream(BINFilename, FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, list);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to binary serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                stream.Close();
            }
        }

        public List<Entry> Read()
        {
            List<Entry> list;
            Stream stream = new FileStream(BINFilename, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                IFormatter formatter = new BinaryFormatter();
                list = (List<Entry>) formatter.Deserialize(stream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to binary deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                stream.Close();
            }

            Debug.WriteLine("Liczba odczytanych elementów: {0}", list.Count);

            return list;
        }

    }
}
