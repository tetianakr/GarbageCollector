using System;

namespace FinalizableDisposableClass
{
    class ResourceWrapper : IDisposable
    {
        // Флаг, показывающий вызов метода Dispose()
        private bool disposed = false;

        public void Dispose()
        {
            // Если true, то очистку инициировал пользователь объекта.
            CleanUp(true);

            // SuppressFinalize() - устанавливает флаг запрещения завершения для объектов
            // которые в противном случае могли бы быть завершены сборщиком мусора.
            // Отменяет работу деструктора для данного класса.
            GC.SuppressFinalize(this);
        }

        // Сборщик мусора вызывает деструктор, если пользователь объекта 
        // забудет вызвать метод Dispose().
        ~ResourceWrapper()
        {
            Console.WriteLine("Finalize!!!");
            CleanUp(false);
        }

        // Метод для избежания дублирования кода в деструкторе и методе Dispose().
        private void CleanUp(bool clean)
        {
            // Проверка, что ресурсы еще не освобождены.
            if (!this.disposed)
            {
                if (clean)
                {
                    Console.WriteLine("Освобождение ресурсов.");
                }
                this.disposed = true;
            }
        }
    }
}
