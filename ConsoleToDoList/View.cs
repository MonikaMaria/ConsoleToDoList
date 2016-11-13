using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToDoList
{
    internal class View
    {
        private readonly List<IPersister> persisters;
        private readonly List<Entry> entries;
        private ConsoleKey lastKey = default(ConsoleKey);
        private readonly EntryManager manager;

        public View()
        {
            persisters = new List<IPersister>
            {
                new BinPersister(),
                new TxtPersister(),
                new XmlPersister(),
            };

            entries = new List<Entry>();

            manager = new EntryManager();
        }

        public void Start()
        {
            Console.WriteLine("A - dodaj element");
            Console.WriteLine("E - edytuj element");
            Console.WriteLine("D - usuń element");
            Console.WriteLine("W - pokaż listę");
            Console.WriteLine("C - wyczyść okno");
            Console.WriteLine("S - zapisz");
            Console.WriteLine("R - wczytaj");
            Console.WriteLine("O - sortuj");
        }

        public void ChooseAction()
        {
            lastKey = Console.ReadKey(true).Key;

            switch (lastKey)
            {
                case ConsoleKey.A:
                    Add();
                    break;
                case ConsoleKey.E:
                    Edit();
                    break;
                case ConsoleKey.W:
                    manager.Display(entries);
                    break;
                case ConsoleKey.D:
                    Delete();
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    Start();
                    break;
                case ConsoleKey.S:
                    Save();
                    break;
                case ConsoleKey.R:
                    entries.Clear();
                    entries.AddRange(persisters.Last().Read());
                    break;
                case ConsoleKey.O: manager.SortByDate(entries);
                    break;
            }
        }

        private void Save()
        {
            foreach (var persister in persisters)
                persister.Write(entries);
        }

        private void Delete()
        {
            Console.WriteLine("--Podaj numer elementu");
            manager.Delete(entries);
            Console.WriteLine("Usunięto.");
        }

        private void Edit()
        {
            Console.WriteLine("--Podaj: numer elementu, a następnie nową wartość");
            manager.Edit(entries);
            Console.WriteLine("Zmieniono.");
        }

        private void Add()
        {
            Console.WriteLine("Wpisz element");
            manager.Add(entries);
            Console.WriteLine("Dodano.");
        }

        public bool ShouldExit() => lastKey == ConsoleKey.X;
    }
}