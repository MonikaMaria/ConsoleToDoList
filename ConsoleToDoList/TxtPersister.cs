using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ConsoleToDoList
{
    class TxtPersister : IPersister
    {
        private static string path = ConfigurationManager.AppSettings["path"];

        public void Write(List<Entry> list)
        {
            int i = 0;
            int numberOfElements = list.Count;
            string[] arrayList;
            arrayList = new string[numberOfElements];
            foreach (Entry entry in list)
            {
                arrayList[i] = entry.ToString();
                i++;
            }
            File.WriteAllLines(path, arrayList);
        }

        public List<Entry> Read()
        {
            List<Entry> list = new List<Entry>();
            Entry newEntry = new Entry();
            string[] lines = File.ReadAllLines(path);
            var dataLength = 16;

            list.Clear();

            foreach (string line in lines)
            {
                DateTime date = (DateTime.Parse(line.Substring(line.Length - dataLength, dataLength)));
                string value = line.Substring(0, line.Length-dataLength);
                newEntry.ValueProperty = value;
                newEntry.DateProperty = date;
                list.Add(newEntry);
                newEntry = new Entry();
            }
            
            return list;
        }
    }
}
