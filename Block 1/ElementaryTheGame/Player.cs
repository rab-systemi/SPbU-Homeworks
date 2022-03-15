public class Player
{
    public int HP = 100;
    public int Damage;
    public int[] Field = new int[4]; //Поле игрока для карт, содержит 4 места
    public string[] FieldToPrint = new string[4]; //Поле игрока для печати
    public int[] Deck = new int[6]; //Рука игрока, максимум - 6 карт
    public string[] DeckToPrint = new string[6]; //Для печати

    public virtual void Ability(Player enemy) { }
    public virtual void Hit(Player enemy) { }
    public void GetDamage(int damage) //Метод получения урона
    {
        HP -= damage;
    }
    public Player ChooseYourElement() //Метод выбора стихии
    {
        ConsoleKeyInfo elementChoice;
        while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
        {
            Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
            ConsoleKeyInfo Choice = Console.ReadKey();
            elementChoice = Choice;

            if (Choice.Key == ConsoleKey.D1) //Пользователь нажал 1
            {
                Console.WriteLine("\nВы выбрали стихию Огня!\n");
                break;
            }
            else if (Choice.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                Console.WriteLine("\nВы выбрали стихию Воды!\n");
                break;
            }
            else if (Choice.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                Console.WriteLine("\nВы выбрали стихию Земли!\n");
                break;
            }
            else if (Choice.Key == ConsoleKey.D4) //Пользователь нажал 4
            {
                Console.WriteLine("\nВы выбрали стихию Воздуха!\n");
                break;
            }
            else //Пользователь нажал что-то еще, а это недопустимо
            {
                Console.WriteLine("\nВведено недопустимое значение. " +
            "Попробуйте, пожалуйста, еще раз.");
                continue;
            }
        }
        switch (elementChoice.Key)
        {
            case ConsoleKey.D1: //Если пользователь выбрал стихию Огня
                return new Fire();
                break;
            case ConsoleKey.D2: //Если пользователь выбрал стихию Воды
                return new Water();
                break;
            case ConsoleKey.D3: //Если пользователь выбрал стихию Земли
                return new Earth();
                break;
            case ConsoleKey.D4: //Если пользователь выбрал стихию Воздуха
                return new Air();
                break;
            default:
                return null;
                break;
        }
    }
    public int RandomValue() //Метод, случайно выбирающий число от 1 до 4
    {
        Random random = new Random();
        int value = random.Next(1, 5);

        return value;
    }

    public void GetCards(int number) //Метод выдачи карт игроку
    {
        for (int i = 0; i < number; i++) //Цикл выдачи карт в количестве number
        {
            Random random = new Random();
            int randomCard = random.Next(1, 11);
            int cardToDelete = random.Next(0, 6); //Переменная для замены карты в руке, если она полная
            bool flag = false;
            for (int j = 0; j < 6; j++)
            {
                if (Deck[j] == 0)
                {
                    if (randomCard == 1)
                    {
                        Deck[j] = 1; //Размещаем гиганта
                    }
                    else if (randomCard == 2 || randomCard == 3)
                    {
                        Deck[j] = 2; //Размещаем доджера урона
                    }
                    else if (randomCard <= 6)
                    {
                        Deck[j] = 3; //Размещаем дамагера
                    }
                    else
                    {
                        Deck[j] = 4; //Размещаем духа
                    }
                    flag = true;
                    break;
                }
                else continue;
            }
            if (!flag) //Рука полная
            {
                if (randomCard == 1)
                {
                    Deck[cardToDelete] = 1; //Размещаем гиганта
                }
                else if (randomCard == 2 || randomCard == 3)
                {
                    Deck[cardToDelete] = 2; //Размещаем доджера урона
                }
                else if (randomCard <= 6)
                {
                    Deck[cardToDelete] = 3; //Размещаем дамагера
                }
                else
                {
                    Deck[cardToDelete] = 4; //Размещаем духа
                }
            }
        }
    }
    public void Move(Player player, Player enemy, Player playerField111, Player playerField2, Player playerField3,
        Player playerField4, Player enemyField1, Player enemyField2, Player enemyField3, Player enemyField4)
    {
        PvsP test = new PvsP();
        playerField111 = new Knight();
        playerField111.GetDamage(2);
        Console.WriteLine(playerField111.HP);
        test.playerField1.GetDamage(4);



        //playerField1 = playerField1.SetCard();
        
        
        
        player.GetCards(1);
        Console.WriteLine("Вы получили карту в начале хода!");
        //PrintSituation(player, enemy, playerField1, playerField2, playerField3, playerField4, ... )
        Console.WriteLine("Пожалуйста. выберите карту в руке (нажмите два раза 1,2,3,4), чтобы разместить на поле, " +
            "используйте способность стихии (нажмите 5) или нажмите ENTER, чтобы завершить ход и начать атаку");
        /*
        while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
        {
            
            Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
            ConsoleKeyInfo cardChoice = Console.ReadKey();
            

            if (cardChoice.Key == ConsoleKey.D1) //Пользователь нажал 1
            {
                bool flagCard = false;
                for(int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 1)
                    {
                        //Выбрать поле для размещения карты
                        flagCard = true;
                    }
                }
                if (!flagCard)
                {
                    Console.WriteLine("У Вас в руке нет данной карты");
                }
                Console.WriteLine("\nВы выбрали режим Игрок против Игрока");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                Console.WriteLine("\nВы выбрали режим Игрок против ИИ");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                Console.WriteLine("\nВы выбрали режим ИИ против ИИ");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D4) //Пользователь нажал 4
            {
                Console.WriteLine("\nВы выбрали режим ИИ против ИИ");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D5) //Пользователь нажал 5
            {
                Console.WriteLine("\nВы выбрали режим ИИ против ИИ");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.Enter) //Пользователь нажал ENTER
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
        */

    }
    //TO FINISH
    public void PrintSituation(Player player, Player enemy, Player playerField1, Player playerField2, Player playerField3,
        Player playerField4, Player enemyField1, Player enemyField2, Player enemyField3, Player enemyField4)
    {
        Console.WriteLine($"Игрок 1: {player.HP} HP");
        for(int i = 0; i < 4; i++)
        {
            if (player is Fire)
            {
                if (player.Field[i] == 1)
                {
                    Console.Write($"Суртур: {player.HP}");
                }
            }
        }
        for(int i = 0; i < 6; i++)
        {
            if (player is Fire)
            {
                if (player.Deck[i] == 1)
                {
                    player.DeckToPrint[i] = $"";
                    
                }
            }
        }
    }

    /*
    private Player SetCard(Player player, Player playerField1, Player playerField2, Player playerField3,Player playerField4,
                            Player enemyField1, Player enemyField2, Player enemyField3, Player enemyField4)
    {
        while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
        {

            Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
            ConsoleKeyInfo cardChoice = Console.ReadKey();


            if (cardChoice.Key == ConsoleKey.D1) //Пользователь нажал 1
            {
                bool flagCard = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 1)
                    {
                        //Выбрать поле для размещения карты
                        
                        flagCard = true;
                        break;
                    }
                }
                if (!flagCard)
                {
                    Console.WriteLine("У Вас в руке нет данной карты. Введите другое значение.");
                    continue;
                }
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                Console.WriteLine("\nВы выбрали режим Игрок против ИИ");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                Console.WriteLine("\nВы выбрали режим ИИ против ИИ");
                break;
            }
            else if (cardChoice.Key == ConsoleKey.D4) //Пользователь нажал 4
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
    }
    
    public void Test(Player test)
    {
        test = new Knight();
    }
    public Player TestSet()
    {
        return new Knight();

    }
    */
}