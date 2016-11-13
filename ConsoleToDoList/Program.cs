namespace ConsoleToDoList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var view = new View();
            view.Start();
            while (!view.ShouldExit())
                view.ChooseAction();
        }
    }
}




