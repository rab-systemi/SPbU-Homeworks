using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryOverflowException
    {
        public void OverflowException(int number)
        {
            Console.WriteLine("Исключение \"OverflowException\": принимаем целое число и вычисляем его квадрат.\n" +
                "Если квадрат вышел за границы допустимых значений Int32 - исключение\n");
            
            try
            {
                int tryResult = checked(number * number);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("Квадрат числа вышел за границы допустимых значений Int32. Так нельзя.");
                return;
            }

            int result = number * number;
            Console.WriteLine($"Квадрат числа {number}: {result}");
            
        }
    }
}
