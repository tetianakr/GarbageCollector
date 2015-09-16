using System;
using System.Runtime;
using System.Threading;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            // Метод GetTotalMemory возвращает размер памяти в байтах которую занимают объекты в управляемой куче.
            Console.WriteLine("Размер памяти в байтах в управляемой куче {0}", GC.GetTotalMemory(false));

            // Свойство MaxGeneration возвращает максимальное количество поколений, поддерживаемое данной системой.
            Console.WriteLine("Система поддерживает {0} поколения\n", (GC.MaxGeneration + 1));
           
            Car car = new Car("RENAULT", 120);
            Console.WriteLine(car.ToString());

            // Метод GetGeneration() возвращает поколение, к которому относится данный объект.
            Console.WriteLine("\nОбъект car относится к {0} поколению\n", GC.GetGeneration(car));
            Console.WriteLine("Размер памяти в байтах в управляемой куче {0}", GC.GetTotalMemory(false));

            object[] array = new object[10000000];            
            ShowGCStart();

            for (int i=0; i<array.Length; i++)
            {
                array[i] = new object();
            }

            Console.WriteLine("Размер памяти в байтах в управляемой куче {0}", GC.GetTotalMemory(false));
            array = null;
            ShowGCStart();

            Console.WriteLine("\nМассив построен, запускаем GC ");
            
            // Метод Collect() - дает указание сборщику мусора проверить объекты определенного поколения
            GC.Collect();

            ShowGCStart();

            // Метод WaitForPendingFinalizers() приостанавливает выполнение текущего потока, пока 
            // не будут отработаны все объекты, предусматривающие финализацию.
            GC.WaitForPendingFinalizers();

            Console.WriteLine("GC отработал   " + (DateTime.Now - start).TotalMilliseconds + "\n");
            Console.WriteLine("Размер памяти в байтах в управляемой куче {0}", GC.GetTotalMemory(false));
            Console.WriteLine("\nОбъект car относится к {0} поколению\n", GC.GetGeneration(car));
        }

        private static void ShowGCStart()
        {
            // Метод CollectionCount() возвращает числовое значение, сколько раз данное
            // поколение выживало при сборке мусора.
            Console.WriteLine("\nПоколение 0 проверялось {0} раз", GC.CollectionCount(0));
            Console.WriteLine("Поколение 1 проверялось {0} раз", GC.CollectionCount(1));
            Console.WriteLine("Поколение 2 проверялось {0} раз", GC.CollectionCount(2));
        }
    }
}
