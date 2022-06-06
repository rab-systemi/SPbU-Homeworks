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

        private List<KeyValue<string, string>> LocalVariables = new();

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
                List<int> connectorsIndexes = new List<int>();

                if (parsedInput.Length > 0)
                {
                    if (parsedInput[0] == "&&" || parsedInput[0] == "||" || parsedInput[0] == ";")
                    {
                        Console.WriteLine("myBash: syntax error near unexpected token\n");
                        LastResult = 1;
                        continue;
                    }
                    else if (parsedInput[^1] == "&&" || parsedInput[^1] == "||" || parsedInput[^1] == ";")
                    {
                        Console.WriteLine("myBash: syntax error near unexpected token\n");
                        LastResult = 1;
                        continue;
                    }
                }

                for (int i = 0; i < parsedInputLength; i++)
                {
                    if (parsedInput[i] == "&&" || parsedInput[i] == "||" || parsedInput[i] == ";")
                    {
                        connectorsIndexes.Add(i);
                    }
                }
                
                if (connectorsIndexes.Count > 0)
                {
                    int connectorsIndexesCount = connectorsIndexes.Count;
                    int previousConnectorIndex = default;

                    while (connectorsIndexes.Count > 0)
                    {
                        if (connectorsIndexes.Count == connectorsIndexesCount)
                        {
                            if (connectorsIndexesCount == 1)
                            {
                                string[] firstCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                RunCommand(firstCommand);
                                string[] lastCommand = parsedInput.Skip(connectorsIndexes[0] + 1).ToArray();

                                if (parsedInput[connectorsIndexes[0]] == "&&")
                                {
                                    if (LastResult == 0)
                                    {
                                        RunCommand(lastCommand);
                                    }
                                }
                                else if (parsedInput[connectorsIndexes[0]] == "||")
                                {
                                    if (LastResult == 1)
                                    {
                                        RunCommand(lastCommand);
                                    }
                                }
                                else //Единственный коннектор ;
                                {
                                    RunCommand(lastCommand);
                                }
                                connectorsIndexes.RemoveAt(0);
                            }
                            else
                            {
                                string[] firstCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                RunCommand(firstCommand);
                                previousConnectorIndex = connectorsIndexes[0];
                                connectorsIndexes.RemoveAt(0);
                            }
                        }
                        else
                        {
                            if (connectorsIndexes.Count == 1)
                            {
                                if (parsedInput[previousConnectorIndex] == "&&")
                                {
                                    if (LastResult == 0)
                                    {
                                        string[] nextCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                        nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                        RunCommand(nextCommand);
                                    }
                                }
                                else if (parsedInput[previousConnectorIndex] == "||")
                                {
                                    if (LastResult == 1)
                                    {
                                        string[] nextCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                        nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                        RunCommand(nextCommand);
                                    }
                                }
                                else //Единственный коннектор ;
                                {
                                    string[] nextCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                    nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                    RunCommand(nextCommand);
                                }
                                string[] lastCommand = parsedInput.Skip(connectorsIndexes[0] + 1).ToArray();

                                if (parsedInput[(connectorsIndexes[0])] == "&&")
                                {
                                    if (LastResult == 0)
                                    {
                                        RunCommand(lastCommand);
                                    }
                                }
                                else if (parsedInput[(connectorsIndexes[0])] == "||")
                                {
                                    if (LastResult == 1)
                                    {
                                        RunCommand(lastCommand);
                                    }
                                }
                                else //Единственный коннектор ;
                                {
                                    RunCommand(lastCommand);
                                }
                                connectorsIndexes.RemoveAt(0);
                            }
                            else
                            {
                                if (parsedInput[previousConnectorIndex] == "&&")
                                {
                                    if (LastResult == 0)
                                    {
                                        string[] nextCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                        nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                        RunCommand(nextCommand);
                                    }
                                }
                                else if (parsedInput[previousConnectorIndex] == "||")
                                {
                                    if (LastResult == 1)
                                    {
                                        string[] nextCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                        nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                        RunCommand(nextCommand);
                                    }
                                }
                                else //Единственный коннектор ;
                                {
                                    string[] nextCommand = parsedInput.Take(connectorsIndexes[0]).ToArray();
                                    nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                    RunCommand(nextCommand);
                                }
                                previousConnectorIndex = connectorsIndexes[0];
                                connectorsIndexes.RemoveAt(0);

                            }
                        }
                    }
                }
                else
                {
                    RunCommand(parsedInput);
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
                        else if (input[1][0] == '$' && input[1].Length > 1)
                        {
                            string id = input[1].TrimStart('$');
                            string text = "";
                            bool findFlag = false;

                            foreach (var item in LocalVariables)
                            {
                                if (item.Id == id)
                                {
                                    text = item.Text;
                                    findFlag = true;
                                }
                            }

                            if (findFlag)
                            {
                                Console.WriteLine(text);
                                Console.WriteLine();
                                LastResult = 0;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                LastResult = 0;
                            }
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
                            else if (input[i][0] == '$' && input[i].Length > 1)
                            {
                                string id = input[i].TrimStart('$');
                                string text = "";
                                bool findFlag = false;

                                foreach (var item in LocalVariables)
                                {
                                    if (item.Id == id)
                                    {
                                        text = item.Text;
                                        findFlag = true;
                                    }
                                }

                                if (findFlag)
                                {
                                    input[i] = text;
                                }
                                else
                                {
                                    input[i] = "";
                                }
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
                        LastResult = 0;
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
                        LastResult = 1;
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
                case "wc":
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine("myBash: wc: some arguments are required\n");
                        LastResult = 1;
                    }
                    else if (input.Length == 2)
                    {
                        int linesCount = 0;
                        int wordsCount = 0;
                        long bytesCount = 0;
                        string path = @input[1];
                        try
                        {
                            bytesCount = new FileInfo(path).Length; //Считаем количество байт в файле
                            using (StreamReader sr = new StreamReader(path))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    linesCount++;
                                    line = line.Trim();
                                    string[] parsedLine = line.Split();
                                    parsedLine = parsedLine.Where(val => val != "").ToArray();
                                    wordsCount += parsedLine.Length;
                                }
                            }
                            Console.Write(linesCount + " " + wordsCount + " " + bytesCount);
                            Console.WriteLine("\n");
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
                        int linesCount = 0;
                        int wordsCount = 0;
                        long bytesCount = 0;
                        string path = @input[1];
                        try
                        {
                            bytesCount = new FileInfo(path).Length; //Считаем количество байт в файле
                            using (StreamReader sr = new StreamReader(path))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    linesCount++;
                                    line = line.Trim();
                                    string[] parsedLine = line.Split();
                                    parsedLine = parsedLine.Where(val => val != "").ToArray();
                                    wordsCount += parsedLine.Length;
                                }
                            }
                            string outputData = linesCount.ToString() + " " + wordsCount.ToString() + " " + bytesCount.ToString();
                            output.Add(outputData);
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
                case "scr":
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        Console.WriteLine("myBash: scr: some arguments are required\n");
                        LastResult = 1;
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
                                    line = line.Trim().ToLower();

                                    string[] fileCommand = line.Split();
                                    fileCommand = fileCommand.Where(val => val != "").ToArray();
                                    int parsedInputLength = fileCommand.Length;
                                    List<int> connectorsIndexes = new List<int>();

                                    if (fileCommand.Length > 0)
                                    {
                                        if (fileCommand[0] == "&&" || fileCommand[0] == "||" || fileCommand[0] == ";")
                                        {
                                            Console.WriteLine("myBash: syntax error near unexpected token\n");
                                            LastResult = 1;
                                            continue;
                                        }
                                        else if (fileCommand[^1] == "&&" || fileCommand[^1] == "||" || fileCommand[^1] == ";")
                                        {
                                            Console.WriteLine("myBash: syntax error near unexpected token\n");
                                            LastResult = 1;
                                            continue;
                                        }
                                    }

                                    for (int i = 0; i < parsedInputLength; i++)
                                    {
                                        if (fileCommand[i] == "&&" || fileCommand[i] == "||" || fileCommand[i] == ";")
                                        {
                                            connectorsIndexes.Add(i);
                                        }
                                    }

                                    if (connectorsIndexes.Count > 0)
                                    {
                                        int connectorsIndexesCount = connectorsIndexes.Count;
                                        int previousConnectorIndex = default;

                                        while (connectorsIndexes.Count > 0)
                                        {
                                            if (connectorsIndexes.Count == connectorsIndexesCount)
                                            {
                                                if (connectorsIndexesCount == 1)
                                                {
                                                    string[] firstCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                    RunCommand(firstCommand);
                                                    string[] lastCommand = fileCommand.Skip(connectorsIndexes[0] + 1).ToArray();

                                                    if (fileCommand[connectorsIndexes[0]] == "&&")
                                                    {
                                                        if (LastResult == 0)
                                                        {
                                                            RunCommand(lastCommand);
                                                        }
                                                    }
                                                    else if (fileCommand[connectorsIndexes[0]] == "||")
                                                    {
                                                        if (LastResult == 1)
                                                        {
                                                            RunCommand(lastCommand);
                                                        }
                                                    }
                                                    else //Единственный коннектор ;
                                                    {
                                                        RunCommand(lastCommand);
                                                    }
                                                    connectorsIndexes.RemoveAt(0);
                                                }
                                                else
                                                {
                                                    string[] firstCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                    RunCommand(firstCommand);
                                                    previousConnectorIndex = connectorsIndexes[0];
                                                    connectorsIndexes.RemoveAt(0);
                                                }
                                            }
                                            else
                                            {
                                                if (connectorsIndexes.Count == 1)
                                                {
                                                    if (fileCommand[previousConnectorIndex] == "&&")
                                                    {
                                                        if (LastResult == 0)
                                                        {
                                                            string[] nextCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                            nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                                            RunCommand(nextCommand);
                                                        }
                                                    }
                                                    else if (fileCommand[previousConnectorIndex] == "||")
                                                    {
                                                        if (LastResult == 1)
                                                        {
                                                            string[] nextCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                            nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                                            RunCommand(nextCommand);
                                                        }
                                                    }
                                                    else //Единственный коннектор ;
                                                    {
                                                        string[] nextCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                        nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                                        RunCommand(nextCommand);
                                                    }
                                                    string[] lastCommand = fileCommand.Skip(connectorsIndexes[0] + 1).ToArray();

                                                    if (fileCommand[(connectorsIndexes[0])] == "&&")
                                                    {
                                                        if (LastResult == 0)
                                                        {
                                                            RunCommand(lastCommand);
                                                        }
                                                    }
                                                    else if (fileCommand[(connectorsIndexes[0])] == "||")
                                                    {
                                                        if (LastResult == 1)
                                                        {
                                                            RunCommand(lastCommand);
                                                        }
                                                    }
                                                    else //Единственный коннектор ;
                                                    {
                                                        RunCommand(lastCommand);
                                                    }
                                                    connectorsIndexes.RemoveAt(0);
                                                }
                                                else
                                                {
                                                    if (fileCommand[previousConnectorIndex] == "&&")
                                                    {
                                                        if (LastResult == 0)
                                                        {
                                                            string[] nextCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                            nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                                            RunCommand(nextCommand);
                                                        }
                                                    }
                                                    else if (fileCommand[previousConnectorIndex] == "||")
                                                    {
                                                        if (LastResult == 1)
                                                        {
                                                            string[] nextCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                            nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                                            RunCommand(nextCommand);
                                                        }
                                                    }
                                                    else //Единственный коннектор ;
                                                    {
                                                        string[] nextCommand = fileCommand.Take(connectorsIndexes[0]).ToArray();
                                                        nextCommand = nextCommand.Skip(previousConnectorIndex + 1).ToArray();
                                                        RunCommand(nextCommand);
                                                    }
                                                    previousConnectorIndex = connectorsIndexes[0];
                                                    connectorsIndexes.RemoveAt(0);

                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RunCommand(fileCommand);
                                    }
                                }
                            }
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
                default:
                    input = CheckOperators(input);
                    if (input == null)
                    {
                        //Ничего не делаем
                    }
                    else if (input.Length == 1)
                    {
                        if (input[0][0] == '$' && input[0].Length > 1) //TO FINISH
                        {
                            bool findFlag = false;
                            string id = input[0].TrimStart('$');
                            string textCommand = default;

                            foreach (var item in LocalVariables)
                            {
                                if (item.Id == id)
                                {
                                    textCommand = item.Text;
                                    findFlag = true;
                                }
                            }

                            if (findFlag)
                            {
                                string[] command = { textCommand };
                                RunCommand(command);
                            }
                            else
                            {
                                LastResult = 0;
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"myBash: {input[0]}: command not found\n");
                            LastResult = 1;
                        }
                    }
                    else
                    {
                        if (input[1] != "=")
                        {
                            Console.WriteLine($"myBash: {input[0]}: command not found\n");
                            LastResult = 1;
                        }
                        else
                        {
                            if (input.Length == 2)
                            {
                                bool changeFlag = false;

                                for (int i = 0; i < LocalVariables.Count; i++)
                                {
                                    if (LocalVariables[i].Id == input[0])
                                    {
                                        LocalVariables[i].Text = "";
                                        changeFlag = true;
                                    }
                                }
                                if (changeFlag)
                                {
                                    //Ничего не делаем, уже все сделано
                                }
                                else
                                {
                                    LocalVariables.Add(new KeyValue<string, string>(input[0], ""));
                                }
                            }
                            else
                            {
                                bool changeFlag = false;

                                for (int i = 0; i < LocalVariables.Count; i++)
                                {
                                    if (LocalVariables[i].Id == input[0])
                                    {
                                        LocalVariables[i].Text = input[2];
                                        changeFlag = true;
                                    }
                                }
                                if (changeFlag)
                                {
                                    //Ничего не делаем, уже все сделано
                                }
                                else
                                {
                                    LocalVariables.Add(new KeyValue<string, string>(input[0], input[2]));
                                }
                            }
                            Console.WriteLine();
                        }
                    }
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
                            input = null; //
                            //input = input.Skip(1).ToArray();
                            LastResult = 0;
                            break;
                        }
                        else
                        {
                            input = null; //
                            //input = input.Skip(1).ToArray();
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
                            input = null; //
                            //input = input.Skip(1).ToArray();
                            LastResult = 0;
                            break;
                        }
                        else
                        {
                            input = null; //
                            //input = input.Skip(1).ToArray();
                            break;
                        }
                    }
                }
                continue;
            }
        }
    }
}
