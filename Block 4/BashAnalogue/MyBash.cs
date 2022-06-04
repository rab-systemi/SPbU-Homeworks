using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashAnalogue
{
    internal class MyBash
    {
        PwdCommand pwd = new();
        CatCommand cat = new();
        EchoCommand echo = new();
        TrueCommand trueCommand = new();
        FalseCommand falseCommand = new();
        DollarQuestionCommand dollarQuestion = new();
        WcCommand wc = new();

        private int LastResult;
        public void Run()
        {
            string[] parsedInput;

            while (true)
            {
                Console.Write("$ ");
                string input = Console.ReadLine();

                parsedInput = input.Split(' ');

                int parsedInputLength = parsedInput.Length;

                while (parsedInput != null && parsedInput.Length > 0)
                {
                    for (int i = 0; i < parsedInput.Length; i++)
                    {
                        if (parsedInput[i] == "&&") /////
                        {
                            if (parsedInput.Length == parsedInputLength) //Если массив ввода не менялся
                            {
                                string[] firstCommand = parsedInput.Take(i).ToArray();
                                
                                parsedInput = parsedInput.Skip(i + 1).ToArray(); //Код, исполняющий firstCommand
                                break;
                            }
                            else //Если массив ввода был изменен
                            {
                                string[] secondCommand = parsedInput.Take(i).ToArray();
                                if (LastResult == 0)
                                {
                                    RunCommand(secondCommand); //Код, исполняющий secondCommand
                                }
                                parsedInput = parsedInput.Skip(i + 1).ToArray();
                                break;
                            }
                        }
                        else if (parsedInput[i] == "||") /////
                        {
                            if (parsedInput.Length == parsedInputLength) //Если массив ввода не менялся
                            {
                                string[] firstCommand = parsedInput.Take(i).ToArray();
                                RunCommand(firstCommand);
                                parsedInput = parsedInput.Skip(i + 1).ToArray();
                                break;
                            }
                            else //Если массив ввода был изменен
                            {
                                string[] secondCommand = parsedInput.Take(i).ToArray();
                                if (LastResult != 0)
                                {
                                    RunCommand(secondCommand);
                                }
                                parsedInput = parsedInput.Skip(i + 1).ToArray();
                                break;
                            }
                        }
                        else if (parsedInput[i] == ";") /////
                        {
                            string[] currentCommand = parsedInput.Take(i).ToArray();
                            RunCommand(currentCommand);
                            parsedInput = parsedInput.Skip(i + 1).ToArray();
                            break;
                        }
                        else
                        {
                            RunCommand(parsedInput);
                            parsedInput = null;
                            break;
                        }
                    }
                    continue;
                }
            }
        }

        private void RunCommand(string[] input) //TO FINISH
        {
            switch (input[0])
            {
                case "pwd": //
                    CheckOperators(input);
                    input = input.Skip(1).ToArray();
                    FileManager(input, pwd);
                    break;
                default:
                    //Какой-то код
                    break;
            }
        }

        private void CheckOperators(string[] command)
        {
            if (command[^1] == ">" || command[^1] == "<")
            {
                Console.WriteLine("myBash: syntax error near unexpected token 'newline'");
                command = default;
                LastResult = 1;
            }
        }

        private void FileManager(string[] input, Command command)
        {
            bool fileWriteFlag = false; //Флажок записи в файл: если false, то в файл ничего не записывалось. True - иначе
            while (input != null && input.Length > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ">" && input.Length > (i + 1))
                    {
                        string fullPath = @input[i + 1]; //Если пользователь ввел полный путь для файла
                        string currentDirectory = Directory.GetCurrentDirectory() + "\\";
                        string currentPath = currentDirectory + input[i + 1]; //Если пользователь ввел только название файла

                        if (File.Exists(fullPath)) //Если файл по полному пути существует
                        {
                            using (StreamWriter writer = new StreamWriter(fullPath, false))
                            {
                                writer.WriteLine(command.Run());
                            }
                            //File.WriteAllText(fullPath, command.Run());
                            input = input.Skip(i + 2).ToArray();
                            LastResult = 0;
                            fileWriteFlag = true;
                            break;
                        }
                        else if (!File.Exists(fullPath)) //Если файл по полному пути НЕ существует
                        {
                            try
                            {
                                using (StreamWriter writer = new StreamWriter(fullPath, false))
                                {
                                    writer.WriteLine(command.Run());
                                }
                                /*
                                File.Create(fullPath);
                                using (StreamWriter sw = File.CreateText(fullPath))
                                {
                                    sw.WriteLine(command.Run());
                                }
                                */
                                input = input.Skip(i + 2).ToArray();
                                LastResult = 0;
                                fileWriteFlag = true;
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(@$"myBash: {fullPath}: No such file or directory");
                                input = null;
                                LastResult = 1;
                                break;
                            }
                        }
                        /*
                        else if (File.Exists(currentPath)) //Если файл по названию существует
                        {
                            File.WriteAllText(currentPath, command.Run());
                            input = input.Skip(i + 2).ToArray();
                            LastResult = 0;
                            fileWriteFlag = true;
                            break;
                        }
                        else if (!File.Exists(currentPath)) //Если файл по названию НЕ существует
                        {
                            try
                            {
                                File.Create(currentPath);
                                using (StreamWriter sw = File.CreateText(currentPath))
                                {
                                    sw.WriteLine(command.Run());
                                }
                                input = input.Skip(i + 2).ToArray();
                                LastResult = 0;
                                fileWriteFlag = true;
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(@$"myBash: {currentPath}: No such file or directory");
                                input = null;
                                LastResult = 1;
                                break;
                            }
                        }
                        */
                    }
                    else if (input[i] == ">>" && input.Length > (i + 1))
                    {
                        string fullPath = @input[i + 1]; //Если пользователь ввел полный путь для файла
                        string currentDirectory = Directory.GetCurrentDirectory() + "\\";
                        string currentPath = currentDirectory + input[i + 1]; //Если пользователь ввел только название файла

                        if (File.Exists(fullPath)) //Если файл по полному пути существует
                        {
                            using (StreamWriter writer = new StreamWriter(fullPath, true))
                            {
                                writer.WriteLine(command.Run());
                            }
                            //File.WriteAllText(fullPath, command.Run());
                            input = input.Skip(i + 2).ToArray();
                            LastResult = 0;
                            fileWriteFlag = true;
                            break;
                        }
                        else if (!File.Exists(fullPath)) //Если файл по полному пути НЕ существует
                        {
                            try
                            {
                                using (StreamWriter writer = new StreamWriter(fullPath, true))
                                {
                                    writer.WriteLine(command.Run());
                                }
                                /*
                                File.Create(fullPath);
                                using (StreamWriter sw = File.CreateText(fullPath))
                                {
                                    sw.WriteLine(command.Run());
                                }
                                */
                                input = input.Skip(i + 2).ToArray();
                                LastResult = 0;
                                fileWriteFlag = true;
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(@$"myBash: {fullPath}: No such file or directory");
                                input = null;
                                LastResult = 1;
                                break;
                            }
                        }
                    }
                    else if (input[i] == "<" && input.Length > (i + 1)) //TO FINISH
                    {
                        string result = command.Run();
                        Console.WriteLine(result);
                        Console.WriteLine();
                    }
                    else
                    {
                        string result = command.Run();
                        Console.WriteLine(result);
                        Console.WriteLine();
                    }
                }
                continue;
            }
        }
    }
}
