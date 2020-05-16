using System;
using System.Reflection;
using Practic4dll;
namespace Practic4UseDll
{
    class Program
    {

        static void Main(string[] args)
        {
            MyDll s = new MyDll();

            Console.WriteLine("Результат функции = "+s.Formula(8,9));
            Console.ReadLine();
        }
    }
}
