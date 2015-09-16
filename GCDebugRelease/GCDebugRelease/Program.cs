using System;
using System.Threading;

namespace GCDebugRelease
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer(Method, "Hello", 0, 200);

            Console.ReadKey();
            timer.Dispose();
        }

        static void Method(object state)
        {
            Console.WriteLine(state);
            GC.Collect();
        }
    }
}
