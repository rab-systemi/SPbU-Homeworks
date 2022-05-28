using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryKeyNotFoundException
    {
        public void KeyNotFoundExceptionNotFixed(Dictionary<int, string> dict, int key)
        {
            Console.WriteLine("Исключение \"KeyNotFoundException\": принимаем словарь и ключ. Выводим значение по указанному ключу.\n" +
                "Если ключа не существует - исключение.\n");

            string value = dict[key];
            Console.WriteLine(value);
        }

        public void KeyNotFoundExceptionFixed(Dictionary<int, string> dict, int key)
        {
            Console.WriteLine("Исключение \"KeyNotFoundException\": принимаем словарь и ключ. Выводим значение по указанному ключу.\n" +
                "Если ключа не существует - исключение.\n");

            try
            {
                string tryValue = dict[key];
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("Пытаемся получить значение по несуществующему ключу. Так нельзя.");
                return;
            }

            string value = dict[key];
            Console.WriteLine(value);
        }
    }
}
