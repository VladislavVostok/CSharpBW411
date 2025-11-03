using _02_Interfaces.Interfaces;

namespace _02_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var _class = new Class1();

            _class.WorkEnded += Class_WorkEnded;

            _class.Work();

            Console.WriteLine("Hello, World!");
        }


        private static void Class_WorkEnded(object sender, EventArgs e)
        {
            Console.WriteLine("Работа завершена!");
        }
    }
}