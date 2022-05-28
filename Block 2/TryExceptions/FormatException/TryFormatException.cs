using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryFormatException
    {
        public void FormatException(string number)
        {
            Console.WriteLine("Исключение \"FormatException\": принимаем строку, конвертируем ее в целое число и вычисляем квадрат этого числа.\n" +
                "Если в строке не число, или оно не целое - исключение\n");

            try
            {
                int.Parse(number);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("В строке содержалось не число, или число было не целым. Так нельзя.");
                return;
            }

            int result = int.Parse(number);
            Console.WriteLine($"Квадрат числа {result}: {result * result}");
        }
    }
}
