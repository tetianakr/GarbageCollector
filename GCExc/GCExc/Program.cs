using System;
using System.Threading.Tasks;

namespace GCExc
{
    class Test
    {
        int[] array = new int[10000000]; // 10 000 000 Б * 4 = 40 000 000 Б = 39 063 КБ = 38 МБ

        public void Method(int i)
        {
            Console.WriteLine(i);
        }

        // Деструктор. - Вызывается Мборщик Мусора.
        ~Test()
        {
            Console.WriteLine("Объект " + this.GetHashCode() + " удален");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            var tests = new Test[1000]; // 38 * 1000 = 38 000 МБ = 38 ГБ - размер всего массива

            try
            {
                for (int i = 0; i < tests.Length; i++)
                {
                    //Test test = new Test();
                    //test.Method(i);

                    tests[i] = new Test();
                    tests[i].Method(i);
                }
            }
            catch (OutOfMemoryException ex)
            {                
                Console.WriteLine(ex.Message);
                Console.WriteLine("Управляемая куча переполнена");               
            }
            Console.ReadKey();
        }        
    }
}

