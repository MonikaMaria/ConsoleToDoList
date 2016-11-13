using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoList
{
    internal class EntryManager 
    {
        public bool Edit(List<Entry> list)
        {
            int index = Choose();
            if (index < list.Count && index >= 0)
            {
                Entry newEntry = new Entry(Console.ReadLine(), DateTime.Now);
                list[index] = newEntry;
                return true;
            }
            return false;
        }

        public int Choose()
        {
            int index;
            int.TryParse(Console.ReadLine(), out index);
            index--;
            return index;
        }

        public void Add(List<Entry> list)
        {
            var newEntry = new Entry(Console.ReadLine(), DateTime.Now);
            list.Add(newEntry);   
        }

        public bool Delete(List<Entry> list)
        {
            int index = Choose();
            if (index < list.Count && index >= 0)
            {
                list.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void Display(List<Entry> list)
        {
            for (int i = 1; i <= list.Count; i++)
                list.ForEach(item => Console.WriteLine(i++ + ". " + item.ToString()));
        }

        public void SortByDate(List<Entry> list) => list.OrderBy(o => o.DateProperty).ToList();
    }
}
