using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;


namespace ConsoleToDoList
{
    class XmlPersister : IPersister
    {
        private static string XMLFilename = ConfigurationManager.AppSettings["XMLFilename"];

        public void Write(List<Entry> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            TextWriter tw = new StreamWriter(XMLFilename);
            serializer.Serialize(tw, list);
            tw.Close();
        }

        public List<Entry> Read()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            TextReader tr = new StreamReader(XMLFilename);
            List<Entry> list = (List<Entry>) serializer.Deserialize(tr);
            tr.Close();
            return list;
        }
    }
}
