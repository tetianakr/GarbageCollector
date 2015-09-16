using System;
using System.Runtime;

namespace SimpleFinalize
{
    public class ResourceWrapper
    {
        ~ResourceWrapper()
        {
            Console.WriteLine("\nРабота Деструктора.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ResourceWrapper resource = new ResourceWrapper();
            GC.Collect();     

            Console.WriteLine("\nНачало работы.");
            Console.WriteLine("Нажмите клавишу для завершения работы.");
            Console.WriteLine("и вызова Finalize() сборщика мусора.");

            Console.ReadKey();
        }
    }
}
