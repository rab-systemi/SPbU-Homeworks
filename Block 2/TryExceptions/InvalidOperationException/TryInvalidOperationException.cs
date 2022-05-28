using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryInvalidOperationException
    {
        public void InvalidOperationExceptionNotFixed(List<int> numbers)
        {
            Console.WriteLine("Исключение \"InvalidOperationException\": выполняем итерации коллекции целых чисел, " +
                "которые пытаются добавить квадрат каждого целого числа в коллекцию.\n" +
                "Получаем исключение:\n");

            foreach (var number in numbers)
            {
                int square = (int)Math.Pow(number, 2);
                numbers.Add(square);
            }
        }

        public void InvalidOperationExceptionFixed(List<int> numbers)
        {
            Console.WriteLine("Исключение \"InvalidOperationException\": выполняем итерации коллекции целых чисел, " +
                "которые пытаются добавить квадрат каждого целого числа в коллекцию.\n" +
                "Получаем исключение:\n");

            try
            {
                foreach (var number in numbers)
                {
                    int square = (int)Math.Pow(number, 2);
                    numbers.Add(square);
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("При итерации коллекции пытаемся в нее что-то добавить. Так нельзя.");
                return;
            }

            foreach (var number in numbers)
            {
                int square = (int)Math.Pow(number, 2);
                numbers.Add(square);
            }
        }
    }
}
