using System.Collections.Generic;

namespace ConsoleToDoList
{
    internal interface IPersister
    {
        void Write(List<Entry> list);
        List<Entry> Read();
    }
}