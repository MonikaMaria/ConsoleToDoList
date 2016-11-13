using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoList
{
    internal class EntryManager 
    {
        public void Edit(List<Entry> list)
        {
            int index = Choose(); 
            Entry newEntry = new Entry(Console.ReadLine(), DateTime.Now);
            list[index] = newEntry;        
        }

        public int Choose()
        {
            int index;
            //string element = null;
            Int32.TryParse(Console.ReadLine(), out index);
            index--;
            return index;
        }

        public void Add(List<Entry> list)
        {
            var newEntry = new Entry(Console.ReadLine(), DateTime.Now);
            list.Add(newEntry);   
        }

        public void Delete(List<Entry> list)
        {
            int index = Choose();
            //string element = null;
            list.RemoveAt(index);
        }

        public void Display(List<Entry> list)
        {
            for (int i = 1; i <= list.Count; i++)
                list.ForEach(item => Console.WriteLine(i++ + ". " + item.ToString()));
        }

        public void SortByDate(List<Entry> list) => list.OrderBy(o => o.DateProperty).ToList();
    }
}
