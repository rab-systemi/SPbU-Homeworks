public class Fight
{
    public void Start(Player player1, Player player2)
    {
        
        ConsoleKeyInfo gameMode;

        Console.WriteLine("Добро пожаловать в Elementary!\n\n" +
    "Выберите режим игры: Игрок против Игрока (нажмите 1), Игрок против ИИ (нажмите 2), " +
    "ИИ против ИИ (нажмите 3)");
        

        
        while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
        {
            Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
            ConsoleKeyInfo choice = Console.ReadKey();
            gameMode = choice;

            if (choice.Key == ConsoleKey.D1) //Пользователь нажал 1
            {
                Console.WriteLine("\nВы выбрали режим Игрок против Игрока");
                break;
            }
            else if (choice.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                Console.WriteLine("\nВы выбрали режим Игрок против ИИ");
                break;
            }
            else if (choice.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                Console.WriteLine("\nВы выбрали режим ИИ против ИИ");
                break;
            }
            else //Пользователь нажал что-то еще, а это недопустимо
            {
                Console.WriteLine("\nВведено недопустимое значение. " +
            "Попробуйте, пожалуйста, еще раз.");
                continue;
            }
        }

        Console.WriteLine("\nВам на выбор предлагаются 4 стихии, за которые вы можете играть:");
        Console.WriteLine("(подробнее о каждой стихии можно прочитать в файле Readme)");
        Console.WriteLine("\t1. Огонь");
        Console.WriteLine("\t2. Вода");
        Console.WriteLine("\t3. Земля");
        Console.WriteLine("\t4. Воздух");

        if (gameMode.Key == ConsoleKey.D1) //Если пользователь нажал выбрал режим игры 1
        {
            PvsP pvsp = new PvsP(); //Запускаем битву в режиме Игрок против Игрока
            pvsp.RunPvsP(player1, player2);
        }
        else if (gameMode.Key == ConsoleKey.D2) //Если пользователь выбрал режим игры 2
        {
            PvsAI pvsai = new PvsAI(); //Запускаем битву в режиме Игрок против ИИ
            pvsai.RunPvsAI(player1, player2);
        }
        else if (gameMode.Key == ConsoleKey.D3) //Если пользователь выбрал режим игры 3
        {
            AIvsAI aivsai = new AIvsAI(); //Запускаем битву в режиме Игрок против ИИ
            aivsai.RunAIvsAI(player1, player2);
        }
    }
    
}