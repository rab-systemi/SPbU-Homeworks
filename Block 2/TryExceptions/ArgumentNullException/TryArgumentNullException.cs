using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryArgumentNullException
    {
        public void ArgumentNullExceptionNotFixed(string s, string toFind)
        {
            Console.WriteLine("Исключение \"ArgumentNullException\": принимаем две строки. Печатаем индексы начада вхождения второй строки в первую.\n" +
                "Если вторая строка пуста - исключение.\n");

            int[] indexes = FindOccurrences(s, toFind);

            foreach (int i in indexes)
            {
                Console.WriteLine(i);
            }
        }

        public void ArgumentNullExceptionFixed(string s, string toFind)
        {
            Console.WriteLine("Исключение \"ArgumentNullException\": принимаем две строки. Печатаем индексы начада вхождения второй строки в первую.\n" +
                "Если вторая строка пуста - исключение.\n");

            try
            {
                int[] tryIndexes = FindOccurrences(s, toFind);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("Вторая строка была пуста. Так нельзя.");
                return;
            }

            int[] indexes = FindOccurrences(s, toFind);

            foreach (int i in indexes)
            {
                Console.WriteLine(i);
            }
        }

        public int[] FindOccurrences(String s, String f)
        {
            var indexes = new List<int>();
            int currentIndex = 0;
            while (currentIndex >= 0 && currentIndex < s.Length)
            {
                currentIndex = s.IndexOf(f, currentIndex);
                if (currentIndex >= 0)
                {
                    indexes.Add(currentIndex);
                    currentIndex++;
                }
            }
            return indexes.ToArray();
        }
    }
}
