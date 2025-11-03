using System.Collections;

namespace _05_Interfaces_Inheritance
{

    interface IA
    {
        string A1(int n);
        int Show();
    }


    interface IB
    {
        int B1(int n);
        void B2();

        string Show();
    }


    interface IC 
    {
        void C1(int n);
        decimal Show();
    }



    class InherInterface : IC, IA, IB
    {
        public string A1(int n)
        {
            throw new NotImplementedException();
        }

        public int B1(int n)
        {
            throw new NotImplementedException();
        }

        public void B2()
        {
            throw new NotImplementedException();
        }

        public void C1(int n)
        {
            throw new NotImplementedException();
        }

        public decimal Show()
        {
            throw new NotImplementedException();
        }

        int IA.Show()
        {
            throw new NotImplementedException();
        }

        string IB.Show()
        {
            throw new NotImplementedException();
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
