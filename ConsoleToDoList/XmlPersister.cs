using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace ConsoleToDoList
{
    class XmlPersister : IPersister
    {
        private static string XMLFilename = ConfigurationManager.AppSettings["XMLFilename"];

        public void Write(List<Entry> list)
        {
            TextWriter tw = new StreamWriter(XMLFilename);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
                serializer.Serialize(tw, list);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize to XML. Reason: " + e.Message);
                throw;
            }
            finally
            {
                tw.Close();
            }
        }

        public List<Entry> Read()
        {
            List<Entry> list;
            TextReader tr = new StreamReader(XMLFilename);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
                list = (List<Entry>)serializer.Deserialize(tr);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize from XML. Reason: " + e.Message);
                throw;
            }
            finally
            {
                tr.Close();
            }     
            
            return list;
        }
    }
}
