using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryDivideByZeroException
    {
        public bool DivideByZeroException(int dividend, int divisor)
        {
            Console.WriteLine("Исключение \"DivideByZeroException\": проверяем, делится ли одно число на другое нацело.\n" +
                "Если делитель 0 - исключение\n");

            try
            {
                var tryDivide = dividend % divisor;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("В качестве делителя был введен 0. Так нельзя.");
                return false;
            }
            
            int result = dividend % divisor;

            if (result == 0)
            {
                Console.WriteLine($"Число {dividend} делится нацело на {divisor}.");
                return true;
            }
            Console.WriteLine($"Число {dividend} НЕ делится нацело на {divisor}.");
            return false;
        }
    }
}
