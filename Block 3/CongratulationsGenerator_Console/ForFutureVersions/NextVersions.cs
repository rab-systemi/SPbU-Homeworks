using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// //////////////////////////////////////////////FOR FUTURE VERSIONS//////////////////////////////////////////////////////
/// </summary>

namespace CongratulationsGenerator
{
    internal class NextVersions
    {
        public void Start()
        {
            Console.WriteLine("Добро пожаловать в Генератор Поздравлений!\n\n");

            while (true)
            {
                string treatment = TreatmentChoice();

                if (treatment == "ya") //
                {
                    while (true)
                    {
                        string holiday = HolidayChoice();

                        if (holiday == "birthday" | holiday == "new-year" | holiday == "christmas") //
                        {
                            while (true)
                            {
                                string gender = GenderChoice();

                                if (gender == "male") //
                                {
                                    if (holiday == "birthday") //
                                    {
                                        Request(holiday);
                                    }
                                    else if (holiday == "new-year") //
                                    {
                                        Request(holiday);
                                    }
                                    else if (holiday == "christmas") //
                                    {
                                        Request(holiday);
                                    }
                                }
                                else if (gender == "female") //
                                {
                                    if (holiday == "birthday") //
                                    {
                                        //КОД ДЛЯ ГЕНЕРАЦИИ ПОЗДРАВЛЕНИЯ
                                    }
                                    else if (holiday == "new-year") //
                                    {
                                        //КОД ДЛЯ ГЕНЕРАЦИИ ПОЗДРАВЛЕНИЯ
                                    }
                                    else if (holiday == "christmas") //
                                    {
                                        //КОД ДЛЯ ГЕНЕРАЦИИ ПОЗДРАВЛЕНИЯ
                                    }
                                }
                                else if (gender == "back") //
                                {
                                    continue;
                                }
                                else //
                                {
                                    break;
                                }
                            }
                        }
                        else if (holiday == "man" | holiday == "woman") //
                        {
                            if (holiday == "man") //
                            {
                                Request(holiday);
                            }
                            else if (holiday == "woman") //
                            {
                                Request(holiday);
                            }
                        }
                        else if (holiday == "back") //
                        {
                            continue;
                        }
                        else //
                        {
                            break;
                        }
                        break;
                    }

                }
                else if (treatment == "you") //
                {
                    string holiday = HolidayChoice();

                    if (holiday == "birthday" | holiday == "new-year" | holiday == "christmas") //
                    {
                        string gender = GenderChoice();

                        if (gender == "male") //
                        {
                            if (holiday == "birthday") //
                            {

                            }
                            else if (holiday == "new-year") //
                            {

                            }
                            else if (holiday == "christmas") //
                            {

                            }
                        }
                        else if (gender == "female") //
                        {
                            if (holiday == "birthday") //
                            {

                            }
                            else if (holiday == "new-year") //
                            {

                            }
                            else if (holiday == "christmas") //
                            {

                            }
                        }
                        else //
                        {

                        }
                    }
                    else if (holiday == "man" | holiday == "woman") //
                    {
                        if (holiday == "man") //
                        {

                        }
                        else if (holiday == "woman") //
                        {

                        }
                    }
                    else //
                    {

                    }
                }
                else //
                {
                    break;
                }
                break;
            }
        }

        private string HolidayChoice() //ДОБАВИТЬ ВОЗВРАТ НА ШАГ НАЗАД
        {
            Console.WriteLine("Выберите праздник, нажав на клавишу с соответствующим номером:\n");
            Console.WriteLine("1. День Рождения");
            Console.WriteLine("2. Новый Год");
            Console.WriteLine("3. Рождество");
            Console.WriteLine("4. 23 Февраля");
            Console.WriteLine("5. 8 Марта");
            Console.WriteLine("Вы также можете нажать ESC, чтобы закрыть приложение, или 0, чтобы вернуться на шаг назад.\n");

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
                else if (Choice.Key == ConsoleKey.D0) //Пользователь нажал 0 - хочет вернуться на шаг назад
                {
                    Console.WriteLine("\nВы вернулись на шаг назад\n");
                    return "back";
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

        private string TreatmentChoice()
        {
            Console.WriteLine("Выберите обращение, нажав на клавишу с соответствующим номером:\n");
            Console.WriteLine("1. Ты");
            Console.WriteLine("2. Вы");
            Console.WriteLine("Вы также можете нажать ESC, чтобы закрыть приложение.\n");

            ConsoleKeyInfo treatmentChoice;
            while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
            {
                Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                ConsoleKeyInfo Choice = Console.ReadKey();
                treatmentChoice = Choice;

                if (Choice.Key == ConsoleKey.D1) //Пользователь нажал 1 - выбрал обращение на "ТЫ"
                {
                    Console.WriteLine("\nВы выбрали обращение на \"ТЫ\"!\n");
                    return "ya";
                }
                else if (Choice.Key == ConsoleKey.D2) //Пользователь нажал 2 - выбрал обращение на "ВЫ"
                {
                    Console.WriteLine("\nВы выбрали обращение на \"ВЫ\"!\n");
                    return "you";
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

        private string GenderChoice() //ДОБАВИТЬ ВОЗВРАТ НА ШАГ НАЗАД
        {
            Console.WriteLine("Выберите пол, нажав на клавишу с соответствующим номером:\n");
            Console.WriteLine("1. Мужчине");
            Console.WriteLine("2. Женщине");
            Console.WriteLine("Вы также можете нажать ESC, чтобы закрыть приложение, или 0, чтобы вернуться на шаг назад.\n");

            ConsoleKeyInfo genderChoice;
            while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
            {
                Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                ConsoleKeyInfo Choice = Console.ReadKey();
                genderChoice = Choice;

                if (Choice.Key == ConsoleKey.D1) //Пользователь нажал 1 - выбрал поздравление для мужчины
                {
                    Console.WriteLine("\nВы выбрали поздравление для мужчины!\n");
                    return "male";
                }
                else if (Choice.Key == ConsoleKey.D2) //Пользователь нажал 2 - выбрал поздравление для женщины
                {
                    Console.WriteLine("\nВы выбрали поздравление для женщины!\n");
                    return "female";
                }
                else if (Choice.Key == ConsoleKey.D0) //Пользователь нажал 0 - хочет вернуться на шаг назад
                {
                    Console.WriteLine("\nВы вернулись на шаг назад\n");
                    return "back";
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
                        message = (message.Remove(0, 75)).Trim();
                        char[] MyChar = { '<', '/', 's', 'p', 'a', 'n', '>' };
                        message = (message.TrimEnd(MyChar)).Trim();
                        Console.WriteLine(message);
                    }
                }
            }
        }
    }
}

