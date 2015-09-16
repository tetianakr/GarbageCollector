using System;

// IDisposable - как альтернатива Деструктору.

namespace SimpleDispose
{
    // Реализация IDisposable().
    public class MyClass : IDisposable
    {
        // Пользователь объекта должен вызвать этот метод
        // перед завершением работы с объектом.
        public void Dispose()
        {
            // Освобождение неуправляемых ресурсов.
            // Освобождение других содержащихся объектов.
            Console.WriteLine("Метод Dispose() отработал: "+this.GetHashCode());
        }

        // Деструктор.
        ~MyClass()
        {
            Console.WriteLine("Деструктор отработал.");
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var instanse = new MyClass();

            if (instanse is IDisposable)
                instanse.Dispose();

            Console.ReadKey();
        }
    }
}
