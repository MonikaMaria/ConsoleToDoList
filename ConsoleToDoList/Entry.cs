using System;
using System.Xml.Serialization;

namespace ConsoleToDoList
{
    [Serializable]
    [XmlRoot("Entry")]
    public class Entry
    {
        private string value;

        [XmlElement("value")]
        public string ValueProperty
        {
            get { return value; }
            set { this.value = value; }
        }

        private DateTime date;

        [XmlAttribute("date")]
        public DateTime DateProperty
        {
            get { return date; }
            set { date = value; }
        }

        public override string ToString()
        {
            string entry = $"{value} {date:yyyy-MM-dd HH:mm}";
            return entry;
        }

        public Entry()
        {
        }

        public Entry(string value, DateTime date)
        {
            this.value = value;
            this.date = date;
        }
    }
}
