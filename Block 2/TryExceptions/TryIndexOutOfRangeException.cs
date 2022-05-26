using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryIndexOutOfRangeException
    {
        public void IndexOutOfRangeException(int[] array, int index)
        {
            Console.WriteLine("Исключение \"IndexOutOfRangeException\": принимаем массив целых чисел и индекс, выводим значение элемента массива по индексу.\n" +
                "Если вышли за границы массива - исключение\n");

            try
            {
                int tryResult = array[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("Вышли за границы массива. Так нельзя.");
                return;
            }

            int result = array[index];
            Console.WriteLine($"Значение по указанному индексу: {result}");
        }
    }
}
