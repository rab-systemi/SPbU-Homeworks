using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryNullReferenceException
    {
        public void NullReferenceExceptionNotFixed(int[] values, int number)
        {
            Console.WriteLine("Исключение \"NullReferenceException\": получаем массив и целое число - количество элементов в массиве.\n" +
                "Заполняем массив квадратами от 1 до number.\n" +
                "Если массив является null - исключение.\n");

            for (int i = 0; i <= number; i++)
                values[i] = i * i;

            foreach (var value in values)
                Console.WriteLine(value);
        }

        public void NullReferenceExceptionFixed(int[] values, int number)
        {
            Console.WriteLine("Исключение \"NullReferenceException\": получаем массив и целое число - количество элементов в массиве.\n" +
                "Заполняем массив квадратами от 1 до number.\n" +
                "Если массив является null - исключение.\n");

            try
            {
                for (int i = 0; i <= number; i++)
                {
                    values[i] = i * i;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("Массив является null. Так нельзя.");
                return;
            }

            for (int i = 0; i <= number; i++)
            {
                values[i] = i * i;
            }

            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}
