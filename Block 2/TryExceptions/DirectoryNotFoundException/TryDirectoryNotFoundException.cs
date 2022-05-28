using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryExceptions
{
    internal class TryDirectoryNotFoundException
    {
        public void DirectoryNotFoundExceptionNotFixed(string dir)
        {
            Console.WriteLine("Исключение \"DirectoryNotFoundException\": принимаем строку - директорию и пытаемся в нее перейти.\n" +
                "Если директории не существует - исключение.\n");

            Directory.SetCurrentDirectory(dir);
        }

        public void DirectoryNotFoundExceptionFixed(string dir)
        {
            Console.WriteLine("Исключение \"DirectoryNotFoundException\": принимаем строку - директорию Пытаемся в нее перейти.\n" +
                "Если директории не существует - исключение.\n");

            try
            {
                Directory.SetCurrentDirectory(dir);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"\nОшибка: {e.Message}\n");
                Console.WriteLine("Пытаемся перейти в несуществующую директорию. Так нельзя.");
                return;
            }

            Directory.SetCurrentDirectory(dir);
        }
    }
}
