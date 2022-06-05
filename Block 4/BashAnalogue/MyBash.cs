using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashAnalogue
{
    internal class MyBash
    {
        private int LastResult;
        public void Run()
        {
            string[] parsedInput;

            while (true)
            {
                Console.Write("$ ");
                string input = Console.ReadLine();
                input = input.Trim().ToLower();

                parsedInput = input.Split();
                parsedInput = parsedInput.Where(val => val != "").ToArray();

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
            List<string> output = new();

            switch (input[0])
            {
                case "pwd":
                    string pwdResult = Directory.GetCurrentDirectory();
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine(pwdResult);
                        Console.WriteLine();
                        LastResult = 0;
                    }
                    else
                    {
                        output.Add(pwdResult);
                        input = input.Skip(1).ToArray();
                        FileManager(input, output);
                    }
                    output = default;
                    break;
                case "cat":
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine("myBash: cat: some arguments are required\n");
                        LastResult = 1;
                    }
                    else if (input.Length == 2)
                    {
                        string path = @input[1];
                        try
                        {
                            using (StreamReader sr = new StreamReader(path))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                            Console.WriteLine();
                            LastResult = 0;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(@$"myBash: {path}: No such file or directory");
                            Console.WriteLine();
                            LastResult = 1;
                        }
                    }
                    else
                    {
                        string path = @input[1];
                        try
                        {
                            using (StreamReader sr = new StreamReader(path))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    output.Add(line);
                                }
                            }
                            input = input.Skip(2).ToArray();
                            FileManager(input, output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(@$"myBash: {path}: No such file or directory");
                            Console.WriteLine();
                            LastResult = 1;
                        }
                    }
                    output = default;
                    break;
                case "echo":
                    string outputString = "";
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine();
                        LastResult = 0;
                    }
                    else if (input.Length == 2)
                    {
                        if (input[1] == "$?")
                        {
                            Console.WriteLine(LastResult);
                            Console.WriteLine();
                            LastResult = 0;
                        }
                        else
                        {
                            Console.WriteLine(input[1]);
                            Console.WriteLine();
                            LastResult = 0;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < input.Length; i++)
                        {
                            if (input[i] == "$?")
                            {
                                input[i] = LastResult.ToString();
                            }
                            else if (input[i] == ">" || input[i] == "<" || input[i] == ">>")
                            {
                                for (int j = 1; j < i; j++)
                                {
                                    outputString = outputString + input[j];
                                    outputString = outputString + " ";
                                }
                                input = input.Skip(i).ToArray();
                                output.Add(outputString);
                                break;
                            }
                        }
                        if (input[0] == ">" || input[0] == "<" || input[0] == ">>")
                        {
                            FileManager(input, output);
                        }
                        else
                        {
                            for (int i = 1; i < input.Length; i++)
                            {
                                Console.Write(input[i]);
                                Console.Write(" ");
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            LastResult = 0;
                        }
                    }
                    output = default;
                    break;
                case "true":
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        for (int i = 1; i < input.Length; i++)
                        {
                            if (input[i] == ">" || input[i] == "<" || input[i] == ">>")
                            {
                                input = input.Skip(i).ToArray();
                                output.Add("");
                                break;
                            }
                        }
                        if (input[0] == ">" || input[0] == "<" || input[0] == ">>")
                        {
                            FileManager(input, output);
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                    LastResult = 0;
                    output = default;
                    break;
                case "false":
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        for (int i = 1; i < input.Length; i++)
                        {
                            if (input[i] == ">" || input[i] == "<" || input[i] == ">>")
                            {
                                input = input.Skip(i).ToArray();
                                output.Add("");
                                break;
                            }
                        }
                        if (input[0] == ">" || input[0] == "<" || input[0] == ">>")
                        {
                            FileManager(input, output);
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                    LastResult = 1;
                    output = default;
                    break;
                default:
                    //Какой-то код
                    break;
            }
        }

        private string[] CheckOperators(string[] command)
        {
            if (command[^1] == ">" || command[^1] == "<" || command[^1] == ">>")
            {
                Console.WriteLine("myBash: syntax error near unexpected token 'newline'\n");
                command = null;
                LastResult = 1;
                return command;
            }
            return command;
        }

        private void FileManager(string[] input, List<string> output)
        {
            bool fileWriteFlag = false; //Флажок записи в файл: если false, то в файл ничего не записывалось. True - иначе
            while (input != null && input.Length > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ">" && input.Length > (i + 1))
                    {
                        string fullPath = @input[i + 1]; //Путь для файла

                        if (File.Exists(fullPath)) //Если файл существует
                        {
                            using (StreamWriter writer = new StreamWriter(fullPath, false))
                            {
                                foreach (var item in output)
                                {
                                    writer.WriteLine(item);
                                }
                            }
                            input = input.Skip(i + 2).ToArray();
                            LastResult = 0;
                            fileWriteFlag = true;
                            Console.WriteLine();
                            break;
                        }
                        else if (!File.Exists(fullPath)) //Если файл НЕ существует
                        {
                            try
                            {
                                using (StreamWriter writer = new StreamWriter(fullPath, false))
                                {
                                    foreach (var item in output)
                                    {
                                        writer.WriteLine(item);
                                    }
                                }
                                input = input.Skip(i + 2).ToArray();
                                LastResult = 0;
                                fileWriteFlag = true;
                                Console.WriteLine();
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(@$"myBash: {fullPath}: No such file or directory");
                                Console.WriteLine();
                                input = null;
                                LastResult = 1;
                                break;
                            }
                        }
                    }
                    else if (input[i] == ">>" && input.Length > (i + 1))
                    {
                        string fullPath = @input[i + 1]; //Путь для файла

                        if (File.Exists(fullPath)) //Если файл существует
                        {
                            using (StreamWriter writer = new StreamWriter(fullPath, true))
                            {
                                foreach (var item in output)
                                {
                                    writer.WriteLine(item);
                                }
                            }
                            input = input.Skip(i + 2).ToArray();
                            LastResult = 0;
                            fileWriteFlag = true;
                            Console.WriteLine();
                            break;
                        }
                        else if (!File.Exists(fullPath)) //Если файл НЕ существует
                        {
                            try
                            {
                                using (StreamWriter writer = new StreamWriter(fullPath, true))
                                {
                                    foreach (var item in output)
                                    {
                                        writer.WriteLine(item);
                                    }
                                }
                                input = input.Skip(i + 2).ToArray();
                                LastResult = 0;
                                fileWriteFlag = true;
                                Console.WriteLine();
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(@$"myBash: {fullPath}: No such file or directory");
                                Console.WriteLine();
                                input = null;
                                LastResult = 1;
                                break;
                            }
                        }
                    }
                    else if (input[i] == "<" && input.Length > (i + 1)) //TO FINISH
                    {
                        if (!fileWriteFlag)
                        {
                            foreach (var item in output)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine();
                            input = input.Skip(1).ToArray();
                            LastResult = 0;
                            break;
                        }
                        else
                        {
                            input = input.Skip(1).ToArray();
                            break;
                        }
                    }
                    else
                    {
                        if (!fileWriteFlag)
                        {
                            foreach (var item in output)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine();
                            input = input.Skip(1).ToArray();
                            LastResult = 0;
                            break;
                        }
                        else
                        {
                            input = input.Skip(1).ToArray();
                            break;
                        }
                    }
                }
                continue;
            }
        }
    }
}
