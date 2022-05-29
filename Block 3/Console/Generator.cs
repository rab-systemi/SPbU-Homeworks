using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationsGenerator
{
    internal class Generator
    {
        public void Start()
        {
            Console.WriteLine("Добро пожаловать в Генератор Поздравлений!\n\n");

            while (true)
            {
                ConsoleKeyInfo finishChoice;

                string holiday = HolidayChoice();

                if (holiday == null)
                {
                    break;
                }

                while (true)
                {
                    Request(holiday);

                    while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
                    {
                        Console.WriteLine("Нажмите ESC, чтобы выйти из приложения, или 0, чтобы вернуться к выбору праздника.");
                        Console.WriteLine("Вы можете нажать ENTER, чтобы сгенерировать еще одно поздравление.");

                        Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                        ConsoleKeyInfo Choice = Console.ReadKey();
                        finishChoice = Choice;

                        if (Choice.Key == ConsoleKey.D0) //Пользователь нажал 0 - вернулся к выбору праздника
                        {
                            Console.WriteLine("\nВы вернулись к выбору праздника!\n");
                            break;
                        }
                        else if (Choice.Key == ConsoleKey.Escape) //Пользователь нажал ESC - хочет выйти из приложения
                        {
                            Console.WriteLine("\nВы вышли из приложения\n");
                            break;
                        }
                        else if (Choice.Key == ConsoleKey.Enter) //Пользователь нажал ENTER - хочет сгенерировать еще одно поздравление
                        {
                            Console.WriteLine("\nГенерируем новое поздравление:\n");
                            Request(holiday);
                            continue;
                        }
                        else //Пользователь нажал что-то еще, а это недопустимо
                        {
                            Console.WriteLine("\nВведено недопустимое значение. " +
                                "Попробуйте, пожалуйста, еще раз.");
                            continue; //Переходим на новую итерацию - снова ждем от пользователя нажатия клавиши
                        }
                    }
                    break;
                }
                if (finishChoice.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (finishChoice.Key == ConsoleKey.D0)
                {
                    continue;
                }
            }
        }

        private string HolidayChoice()
        {
            Console.WriteLine("Выберите праздник, нажав на клавишу с соответствующим номером:\n");
            Console.WriteLine("1. День Рождения");
            Console.WriteLine("2. Новый Год");
            Console.WriteLine("3. Рождество");
            Console.WriteLine("4. 23 Февраля");
            Console.WriteLine("5. 8 Марта");
            Console.WriteLine("Вы также можете нажать ESC, чтобы закрыть приложение.\n");

            ConsoleKeyInfo holidayChoice;
            while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
            {
                Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                ConsoleKeyInfo Choice = Console.ReadKey();
                holidayChoice = Choice;

                if (Choice.Key == ConsoleKey.D1) //Пользователь нажал 1 - выбрал День Рождения
                {
                    Console.WriteLine("\nВы выбрали День Рождения!\n");
                    return "birthday";
                }
                else if (Choice.Key == ConsoleKey.D2) //Пользователь нажал 2 - выбрал Новый Год
                {
                    Console.WriteLine("\nВы выбрали Новый Год!\n");
                    return "new-year";
                }
                else if (Choice.Key == ConsoleKey.D3) //Пользователь нажал 3 - выбрал Рождество
                {
                    Console.WriteLine("\nВы выбрали Рождество!\n");
                    return "christmas";
                }
                else if (Choice.Key == ConsoleKey.D4) //Пользователь нажал 4 - выбрал 23 Февраля
                {
                    Console.WriteLine("\nВы выбрали 23 Февраля!\n");
                    return "man";
                }
                else if (Choice.Key == ConsoleKey.D5) //Пользователь нажал 5 - выбрал 8 Марта
                {
                    Console.WriteLine("\nВы выбрали 8 Марта!\n");
                    return "woman";
                }
                else if (Choice.Key == ConsoleKey.Escape) //Пользователь нажал ESC - хочет выйти из приложения
                {
                    Console.WriteLine("\nВы вышли из приложения\n");
                    return null;
                }
                else //Пользователь нажал что-то еще, а это недопустимо
                {
                    Console.WriteLine("\nВведено недопустимое значение. " +
                        "Попробуйте, пожалуйста, еще раз.");
                    continue; //Переходим на новую итерацию - снова ждем от пользователя нажатия клавиши
                }
            }
        }

        private void Request(string holiday)
        {
            string url = $"https://pozdrav.in/gen/{holiday}";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        int i = 0;
                        string message = default;

                        if (holiday == "man" | holiday == "woman")
                        {
                            foreach (var ch in result)
                            {
                                if (i == 119)
                                {
                                    message = message + ch;
                                }
                                if (ch == '\n')
                                {
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            foreach (var ch in result)
                            {
                                if (i == 130)
                                {
                                    message = message + ch;
                                }
                                if (ch == '\n')
                                {
                                    i++;
                                }
                            }
                        }
                        message = (message.Remove(0, 75)).Trim();
                        char[] MyChar = { '<', '/', 's', 'p', 'a', 'n', '>' };
                        message = (message.TrimEnd(MyChar)).Trim();
                        Console.WriteLine(message);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
