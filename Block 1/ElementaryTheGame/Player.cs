public class Player
{
    public int HP = 100;
    public int Damage;
    public int[] Field = new int[4]; //Поле игрока для карт, содержит 4 места
    public int[] Deck = new int[6]; //Рука игрока, максимум - 6 карт
    public Player[] Fields = new Player[4]; //Тоже поле игрока для карт, но в нем содержатся объекты типа Player

    public virtual void Ability(Player player, Player enemy) { }
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

    public Player ChooseElementAI()
    {
        int element = RandomValue(5);
        switch (element)
        {
            case 1:
                return new Fire();
                break;
            case 2:
                return new Water();
                break;
            case 3:
                return new Earth();
                break;
            case 4:
                return new Air();
                break;
            default:
                return null;
        }
    }
    public int RandomValue(int number) //Метод, случайно выбирающий число от 1 до number
    {
        Random random = new Random();
        int value = random.Next(1, number);

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
    public void Move(Player player, Player enemy) //Метод хода игрока
    {
        player.GetCards(1);
        Console.WriteLine("Вы получили карту в начале хода!\n\n");

        PrintSituation(player, enemy);   

        Console.WriteLine("Вы можете выбрать карту в руке (нажмите 1,2,3 или 4), чтобы разместить ее на поле, и/или " +
            "использовать способность стихии (нажмите A).");
        Console.WriteLine("Вы также можете нажать I, чтобы посмотреть информацию о стихиях.");
        Console.WriteLine("Чтобы завершить ход и начать атаку, нажмите ENTER!");
        
        
        int abilityCount = 0;
        while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
        {
            Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
            ConsoleKeyInfo press = Console.ReadKey();
            

            if (press.Key == ConsoleKey.D1) //Пользователь нажал 1
            {
                bool cardFlag = false;
                for(int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 1)
                    {
                        bool fieldFlag = false;
                        for (int j = 0; j < 4; j++)
                        {
                            if (player.Field[j] == 0)
                            {
                                fieldFlag = true; //После этой строчки переходим к выбору поля
                                Console.WriteLine("\nВыберите клетку, на которую Вы хотите поместить выбранную карту (нажмите 1,2,3 или 4)");
                                Console.WriteLine("Вы также можете нажать 0, чтобы вернуться назад.");
                                while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
                                {
                                    Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                                    ConsoleKeyInfo choice = Console.ReadKey();

                                    if (choice.Key == ConsoleKey.D1)
                                    {
                                        if (player.Field[0] == 0)
                                        {
                                            player.Field[0] = 1;
                                            if (player is Fire)
                                            {
                                                Player surtur = new Surtur();
                                                player.Fields[0] = surtur;
                                            }
                                            else if (player is Water)
                                            {
                                                Player poseidon = new Poseidon();
                                                player.Fields[0] = poseidon;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player giant = new Giant();
                                                player.Fields[0] = giant;
                                            }
                                            else
                                            {
                                                Player storm = new Storm();
                                                player.Fields[0] = storm;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 1);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D2)
                                    {
                                        if (player.Field[1] == 0)
                                        {
                                            player.Field[1] = 1;
                                            if (player is Fire)
                                            {
                                                Player surtur = new Surtur();
                                                player.Fields[1] = surtur;
                                            }
                                            else if (player is Water)
                                            {
                                                Player poseidon = new Poseidon();
                                                player.Fields[1] = poseidon;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player giant = new Giant();
                                                player.Fields[1] = giant;
                                            }
                                            else
                                            {
                                                Player storm = new Storm();
                                                player.Fields[1] = storm;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 1);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D3)
                                    {
                                        if (player.Field[2] == 0)
                                        {
                                            player.Field[2] = 1;
                                            if (player is Fire)
                                            {
                                                Player surtur = new Surtur();
                                                player.Fields[2] = surtur;
                                            }
                                            else if (player is Water)
                                            {
                                                Player poseidon = new Poseidon();
                                                player.Fields[2] = poseidon;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player giant = new Giant();
                                                player.Fields[2] = giant;
                                            }
                                            else
                                            {
                                                Player storm = new Storm();
                                                player.Fields[2] = storm;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 1);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D4)
                                    {
                                        if (player.Field[3] == 0)
                                        {
                                            player.Field[3] = 1;
                                            if (player is Fire)
                                            {
                                                Player surtur = new Surtur();
                                                player.Fields[3] = surtur;
                                            }
                                            else if (player is Water)
                                            {
                                                Player poseidon = new Poseidon();
                                                player.Fields[3] = poseidon;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player giant = new Giant();
                                                player.Fields[3] = giant;
                                            }
                                            else
                                            {
                                                Player storm = new Storm();
                                                player.Fields[3] = storm;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 1);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D0)
                                    {
                                        Console.WriteLine("\nВы вернулись на шаг назад.");
                                        break;
                                    }
                                    else //Пользователь нажал что-то еще, а это недопустимо
                                    {
                                        Console.WriteLine("\nВведено недопустимое значение. " +
                                    "Попробуйте, пожалуйста, еще раз.");
                                        continue;
                                    }
                                }
                                break;
                            }
                        }
                        if (!fieldFlag)
                        {
                            Console.WriteLine("\nВсе клетки поля заняты, поэтому Вы не можете разместить карту. " +
                                "Введите другое значение.");
                        }
                        cardFlag = true;
                        break;
                    }
                }
                if (!cardFlag)
                {
                    Console.WriteLine("\nУ Вас в руке нет данной карты. Введите другое значение.");
                    continue;
                }
                continue;
            }
            else if (press.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                bool cardFlag = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 2)
                    {
                        bool fieldFlag = false;
                        for (int j = 0; j < 4; j++)
                        {
                            if (player.Field[j] == 0)
                            {
                                fieldFlag = true;
                                Console.WriteLine("\nВыберите клетку, на которую Вы хотите поместить выбранную карту (нажмите 1,2,3 или 4)");
                                Console.WriteLine("Вы также можете нажать 0, чтобы вернуться назад.");
                                while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
                                {
                                    Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                                    ConsoleKeyInfo choice = Console.ReadKey();

                                    if (choice.Key == ConsoleKey.D1)
                                    {
                                        if (player.Field[0] == 0)
                                        {
                                            player.Field[0] = 2;
                                            if (player is Fire)
                                            {
                                                Player guardian = new Guardian();
                                                player.Fields[0] = guardian;
                                            }
                                            else if (player is Water)
                                            {
                                                Player wall = new Wall();
                                                player.Fields[0] = wall;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player treeOfLife = new TreeOfLife();
                                                player.Fields[0] = treeOfLife;
                                            }
                                            else
                                            {
                                                Player eagle = new Eagle();
                                                player.Fields[0] = eagle;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 2);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D2)
                                    {
                                        if (player.Field[1] == 0)
                                        {
                                            player.Field[1] = 2;
                                            if (player is Fire)
                                            {
                                                Player guardian = new Guardian();
                                                player.Fields[1] = guardian;
                                            }
                                            else if (player is Water)
                                            {
                                                Player wall = new Wall();
                                                player.Fields[1] = wall;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player treeOfLife = new TreeOfLife();
                                                player.Fields[1] = treeOfLife;
                                            }
                                            else
                                            {
                                                Player eagle = new Eagle();
                                                player.Fields[1] = eagle;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 2);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D3)
                                    {
                                        if (player.Field[2] == 0)
                                        {
                                            player.Field[2] = 2;
                                            if (player is Fire)
                                            {
                                                Player guardian = new Guardian();
                                                player.Fields[2] = guardian;
                                            }
                                            else if (player is Water)
                                            {
                                                Player wall = new Wall();
                                                player.Fields[2] = wall;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player treeOfLife = new TreeOfLife();
                                                player.Fields[2] = treeOfLife;
                                            }
                                            else
                                            {
                                                Player eagle = new Eagle();
                                                player.Fields[2] = eagle;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 2);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D4)
                                    {
                                        if (player.Field[3] == 0)
                                        {
                                            player.Field[3] = 2;
                                            if (player is Fire)
                                            {
                                                Player guardian = new Guardian();
                                                player.Fields[3] = guardian;
                                            }
                                            else if (player is Water)
                                            {
                                                Player wall = new Wall();
                                                player.Fields[3] = wall;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player treeOfLife = new TreeOfLife();
                                                player.Fields[3] = treeOfLife;
                                            }
                                            else
                                            {
                                                Player eagle = new Eagle();
                                                player.Fields[3] = new Eagle();
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 2);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D0)
                                    {
                                        Console.WriteLine("\nВы вернулись на шаг назад.");
                                        break;
                                    }
                                    else //Пользователь нажал что-то еще, а это недопустимо
                                    {
                                        Console.WriteLine("\nВведено недопустимое значение. " +
                                    "Попробуйте, пожалуйста, еще раз.");
                                        continue;
                                    }
                                }
                                break;
                            }
                        }
                        if (!fieldFlag)
                        {
                            Console.WriteLine("\nВсе клетки поля заняты, поэтому Вы не можете разместить карту. " +
                                "Введите другое значение");
                        }
                        cardFlag = true;
                        break;
                    }
                }
                if (!cardFlag)
                {
                    Console.WriteLine("\nУ Вас в руке нет данной карты. Введите другое значение.");
                    continue;
                }
                continue;
            }
            else if (press.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                bool cardFlag = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 3)
                    {
                        bool fieldFlag = false;
                        for (int j = 0; j < 4; j++)
                        {
                            if (player.Field[j] == 0)
                            {
                                fieldFlag = true;
                                Console.WriteLine("\nВыберите клетку, на которую Вы хотите поместить выбранную карту (нажмите 1,2,3 или 4)");
                                Console.WriteLine("Вы также можете нажать 0, чтобы вернуться назад.");
                                while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
                                {
                                    Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                                    ConsoleKeyInfo choice = Console.ReadKey();

                                    if (choice.Key == ConsoleKey.D1)
                                    {
                                        if (player.Field[0] == 0)
                                        {
                                            player.Field[0] = 3;
                                            if (player is Fire)
                                            {
                                                Player knight = new Knight();
                                                player.Fields[0] = knight;
                                            }
                                            else if (player is Water)
                                            {
                                                Player aquaman = new Aquaman();
                                                player.Fields[0] = aquaman;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player stoneBrothers = new StoneBrothers();
                                                player.Fields[0] = stoneBrothers;
                                            }
                                            else
                                            {
                                                Player ninja = new Ninja();
                                                player.Fields[0] = ninja;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 3);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D2)
                                    {
                                        if (player.Field[1] == 0)
                                        {
                                            player.Field[1] = 3;
                                            if (player is Fire)
                                            {
                                                Player knight = new Knight();
                                                player.Fields[1] = knight;
                                            }
                                            else if (player is Water)
                                            {
                                                Player aquaman = new Aquaman();
                                                player.Fields[1] = aquaman;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player stoneBrothers = new StoneBrothers();
                                                player.Fields[1] = stoneBrothers;
                                            }
                                            else
                                            {
                                                Player ninja = new Ninja();
                                                player.Fields[1] = ninja;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 3);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D3)
                                    {
                                        if (player.Field[2] == 0)
                                        {
                                            player.Field[2] = 3;
                                            if (player is Fire)
                                            {
                                                Player knight = new Knight();
                                                player.Fields[2] = knight;
                                            }
                                            else if (player is Water)
                                            {
                                                Player aquaman = new Aquaman();
                                                player.Fields[2] = aquaman;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player stoneBrothers = new StoneBrothers();
                                                player.Fields[2] = stoneBrothers;
                                            }
                                            else
                                            {
                                                Player ninja = new Ninja();
                                                player.Fields[2] = ninja;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 3);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D4)
                                    {
                                        if (player.Field[3] == 0)
                                        {
                                            player.Field[3] = 3;
                                            if (player is Fire)
                                            {
                                                Player knight = new Knight();
                                                player.Fields[3] = knight;
                                            }
                                            else if (player is Water)
                                            {
                                                Player aquaman = new Aquaman();
                                                player.Fields[3] = aquaman;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player stoneBrothers = new StoneBrothers();
                                                player.Fields[3] = stoneBrothers;
                                            }
                                            else
                                            {
                                                Player ninja = new Ninja();
                                                player.Fields[3] = ninja;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 3);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D0)
                                    {
                                        Console.WriteLine("\nВы вернулись на шаг назад.");
                                        break;
                                    }
                                    else //Пользователь нажал что-то еще, а это недопустимо
                                    {
                                        Console.WriteLine("\nВведено недопустимое значение. " +
                                    "Попробуйте, пожалуйста, еще раз.");
                                        continue;
                                    }
                                }
                                break;
                            }
                        }
                        if (!fieldFlag)
                        {
                            Console.WriteLine("\nВсе клетки поля заняты, поэтому Вы не можете разместить карту. " +
                                "Введите другое значение");
                        }
                        cardFlag = true;
                        break; ;
                    }
                }
                if (!cardFlag)
                {
                    Console.WriteLine("\nУ Вас в руке нет данной карты. Введите другое значение.");
                    continue;
                }
                continue;
            }
            else if (press.Key == ConsoleKey.D4) //Пользователь нажал 4
            {
                bool cardFlag = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 4)
                    {
                        bool fieldFlag = false;
                        for (int j = 0; j < 4; j++)
                        {
                            if (player.Field[j] == 0)
                            {
                                fieldFlag = true;
                                Console.WriteLine("\nВыберите клетку, на которую Вы хотите поместить выбранную карту (нажмите 1,2,3 или 4)");
                                Console.WriteLine("Вы также можете нажать 0, чтобы вернуться назад.");
                                while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
                                {
                                    Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
                                    ConsoleKeyInfo choice = Console.ReadKey();
                                    if (choice.Key == ConsoleKey.D1)
                                    {
                                        if (player.Field[0] == 0)
                                        {
                                            player.Field[0] = 4;
                                            if (player is Fire)
                                            {
                                                Player fireSpirit = new FireSpirit();
                                                player.Fields[0] = fireSpirit;
                                            }
                                            else if (player is Water)
                                            {
                                                Player waterSpirit = new WaterSpirit();
                                                player.Fields[0] = waterSpirit;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player earthSpirit = new EarthSpirit();
                                                player.Fields[0] = earthSpirit;
                                            }
                                            else
                                            {
                                                Player airSpirit = new AirSpirit();
                                                player.Fields[0] = airSpirit;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 4);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D2)
                                    {
                                        if (player.Field[1] == 0)
                                        {
                                            player.Field[1] = 4;
                                            if (player is Fire)
                                            {
                                                Player fireSpirit = new FireSpirit();
                                                player.Fields[1] = fireSpirit;
                                            }
                                            else if (player is Water)
                                            {
                                                Player waterSpirit = new WaterSpirit();
                                                player.Fields[1] = waterSpirit;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player earthSpirit = new EarthSpirit();
                                                player.Fields[1] = earthSpirit;
                                            }
                                            else
                                            {
                                                Player airSpirit = new AirSpirit();
                                                player.Fields[1] = airSpirit;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 4);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D3)
                                    {
                                        if (player.Field[2] == 0)
                                        {
                                            player.Field[2] = 4;
                                            if (player is Fire)
                                            {
                                                Player fireSpirit = new FireSpirit();
                                                player.Fields[2] = fireSpirit;
                                            }
                                            else if (player is Water)
                                            {
                                                Player waterSpirit = new WaterSpirit();
                                                player.Fields[2] = waterSpirit;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player earthSpirit = new EarthSpirit();
                                                player.Fields[2] = earthSpirit;
                                            }
                                            else
                                            {
                                                Player airSpirit = new AirSpirit();
                                                player.Fields[2] = airSpirit;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 4);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D4)
                                    {
                                        if (player.Field[3] == 0)
                                        {
                                            player.Field[3] = 4;
                                            if (player is Fire)
                                            {
                                                Player fireSpirit = new FireSpirit();
                                                player.Fields[3] = fireSpirit;
                                            }
                                            else if (player is Water)
                                            {
                                                Player waterSpirit = new WaterSpirit();
                                                player.Fields[3] = waterSpirit;
                                            }
                                            else if (player is Earth)
                                            {
                                                Player earthSpirit = new EarthSpirit();
                                                player.Fields[3] = earthSpirit;
                                            }
                                            else
                                            {
                                                Player airSpirit = new AirSpirit();
                                                player.Fields[3] = airSpirit;
                                            }
                                            Console.WriteLine("\nВы успешно разместили карту!");
                                            CellClearing(player, 4);
                                            PrintSituation(player, enemy);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nДанная клетка занята. Введите другое значение либо нажмите 0 для возврата.");
                                            continue;
                                        }
                                    }
                                    else if (choice.Key == ConsoleKey.D0)
                                    {
                                        Console.WriteLine("\nВы вернулись на шаг назад.");
                                        break;
                                    }
                                    else //Пользователь нажал что-то еще, а это недопустимо
                                    {
                                        Console.WriteLine("\nВведено недопустимое значение. " +
                                    "Попробуйте, пожалуйста, еще раз.");
                                        continue;
                                    }
                                }
                                break;
                            }
                        }
                        if (!fieldFlag)
                        {
                            Console.WriteLine("\nВсе клетки поля заняты, поэтому Вы не можете разместить карту. " +
                                "Введите другое значение");
                        }
                        cardFlag = true;
                        break;
                    }
                }
                if (!cardFlag)
                {
                    Console.WriteLine("\nУ Вас в руке нет данной карты. Введите другое значение.");
                    continue;
                }
                continue;
            }
            else if (press.Key == ConsoleKey.A) //Пользователь нажал A
            {
                if (abilityCount == 0)
                {
                    Console.WriteLine("\nВы применили способность башни!");
                    player.Ability(player, enemy);
                    for (int i = 0; i < 4; i++)
                    {
                        if (enemy.Field[i] != 0)
                        {
                            if (enemy.Fields[i].HP <= 0) //Если удар оказался достаточно сильным
                            {
                                enemy.Field[i] = 0; //Очищаем клетку противника
                                enemy.Fields[i] = null;
                            }
                        }
                    }
                    abilityCount++;
                    continue;
                }
                else
                {
                    Console.WriteLine("\nВы уже применили спсобность башни на этом ходу. Введите другое значение.");
                    continue;
                }
            }
            else if (press.Key == ConsoleKey.I) //Пользователь нажал ENTER
            {
                Console.WriteLine("\n\n\tСтихия Огня: Рыцарь(7 HP,14 урона), Хранитель(14 HP,3 урона), Суртур(20 HP,20 урона), Дух Огня(3 HP, 3 урона)");
                Console.WriteLine("Способность стихии Огня: запускает Fireball по башне противника, нанося по ней 10 урона.");
                Console.WriteLine("\tСтихия Воды: Аквамен(10 HP,10 урона), Водная стена(17 HP,1 урона), Посейдон(17 HP,23 урона), Дух Воды(3 HP, 3 урона)");
                Console.WriteLine("Способность стихии Воды: топит башню и карты противника, нанося всем 3 урона.");
                Console.WriteLine("\tСтихия Земли: Каменные братья(12 HP,8 урона), Древо Жизни(20 HP,0 урона), Гигант(23 HP,17 урона), Дух Земли(3 HP, 3 урона)");
                Console.WriteLine("Способность стихии Земли: устраивает землетрясение, нанося картам противника 6 урона.");
                Console.WriteLine("\tСтихия Воздуха: Ниндзя(8 HP,12 урона), Орёл(15 HP,5 урона), Шторм(19 HP,21 урона), Дух Воздуха(3 HP, 3 урона)");
                Console.WriteLine("Способность стихии Воздуха: обращается за помощью к Солнцу: башня игрока получает 6 HP, по башне противника наносится 4 урона.\n\n");
                continue;
            }
            else if (press.Key == ConsoleKey.Enter) //Пользователь нажал ENTER
            {
                Console.WriteLine("\nВы завершили свой ход. Начинается атака!");
                break;
            }
            else //Пользователь нажал что-то еще, а это недопустимо
            {
                Console.WriteLine("\nВведено недопустимое значение. " +
            "Попробуйте, пожалуйста, еще раз.");
                continue;
            }
        }


        /////////////////////////////////////////////////////////////////
        //Процесс атаки

        for (int i = 0; i < 4; i++) //Цикл проходится по клеткам обоих игроков
        {
            if (player.Field[i] != 0) //Если на клетке есть карта игрока
            {
                if (enemy.Field[i] != 0) //Если на клетке напротив есть карта противника
                {
                    player.Fields[i].Hit(enemy.Fields[i]); //Удар по карте противника
                    if (enemy.Fields[i].HP <= 0) //Если удар оказался достаточно сильным
                    {
                        enemy.Field[i] = 0; //Очищаем клетку противника
                        enemy.Fields[i] = null; 
                    }
                }
                else
                {
                    player.Fields[i].Hit(enemy);
                }
            }
        }
    }

    public void MoveAI(Player player, Player enemy)
    {
        player.GetCards(1);
        Console.WriteLine("ИИ получил карту в начале хода!\n\n");

        PrintSituation(player, enemy);

        for (int i = 0; i < 4; i++)
        {
            int fieldFlag = RandomValue(3);
            if (player.Field[i] == 0)
            {
                if (fieldFlag == 1)
                {
                    for(int j = 0; j < 6; j++)
                    {
                        int cardFlag = RandomValue(3);
                        if(player.Deck[j] != 0)
                        {
                            if(cardFlag == 1)
                            {
                                if (player.Deck[j] == 1)
                                {
                                    player.Field[i] = 1;
                                    if (player is Fire)
                                    {
                                        Player surtur = new Surtur();
                                        player.Fields[i] = surtur;
                                    }
                                    else if (player is Water)
                                    {
                                        Player poseidon = new Poseidon();
                                        player.Fields[i] = poseidon;
                                    }
                                    else if (player is Earth)
                                    {
                                        Player giant = new Giant();
                                        player.Fields[i] = giant;
                                    }
                                    else
                                    {
                                        Player storm = new Storm();
                                        player.Fields[i] = storm;
                                    }
                                    Console.WriteLine("ИИ успешно разместил карту!");
                                    CellClearing(player, 1);
                                    PrintSituation(player, enemy);
                                }
                                else if (player.Deck[j] == 2)
                                {
                                    player.Field[i] = 2;
                                    if (player is Fire)
                                    {
                                        Player guardian = new Guardian();
                                        player.Fields[i] = guardian;
                                    }
                                    else if (player is Water)
                                    {
                                        Player wall = new Wall();
                                        player.Fields[i] = wall;
                                    }
                                    else if (player is Earth)
                                    {
                                        Player treeOfLife = new TreeOfLife();
                                        player.Fields[i] = treeOfLife;
                                    }
                                    else
                                    {
                                        Player eagle = new Eagle();
                                        player.Fields[i] = eagle;
                                    }
                                    Console.WriteLine("ИИ успешно разместил карту!");
                                    CellClearing(player, 2);
                                    PrintSituation(player, enemy);
                                }
                                else if (player.Deck[j] == 3)
                                {
                                    player.Field[i] = 3;
                                    if (player is Fire)
                                    {
                                        Player knight = new Knight();
                                        player.Fields[i] = knight;
                                    }
                                    else if (player is Water)
                                    {
                                        Player aquaman = new Aquaman();
                                        player.Fields[i] = aquaman;
                                    }
                                    else if (player is Earth)
                                    {
                                        Player stoneBrothers = new StoneBrothers();
                                        player.Fields[i] = stoneBrothers;
                                    }
                                    else
                                    {
                                        Player ninja = new Ninja();
                                        player.Fields[i] = ninja;
                                    }
                                    Console.WriteLine("ИИ успешно разместил карту!");
                                    CellClearing(player, 3);
                                    PrintSituation(player, enemy);
                                }
                                else if (player.Deck[j] == 4)
                                {
                                    player.Field[i] = 4;
                                    if (player is Fire)
                                    {
                                        Player fireSpirit = new FireSpirit();
                                        player.Fields[i] = fireSpirit;
                                    }
                                    else if (player is Water)
                                    {
                                        Player waterSpirit = new WaterSpirit();
                                        player.Fields[i] = waterSpirit;
                                    }
                                    else if (player is Earth)
                                    {
                                        Player earthSpirit = new EarthSpirit();
                                        player.Fields[i] = earthSpirit;
                                    }
                                    else
                                    {
                                        Player airSpirit = new AirSpirit();
                                        player.Fields[i] = airSpirit;
                                    }
                                    Console.WriteLine("ИИ успешно разместил карту!");
                                    CellClearing(player, 4);
                                    PrintSituation(player, enemy);
                                }
                            }
                        }
                    }
                }

            }
        }

        int abilityFlag = RandomValue(3);
        if (abilityFlag == 1)
        {
            Console.WriteLine("ИИ применил способность башни!");
            player.Ability(player, enemy);
        }
        for(int i = 0; i < 4; i++)
        {
            if(enemy.Field[i] != 0)
            {
                if (enemy.Fields[i].HP <= 0) //Если удар оказался достаточно сильным
                {
                    enemy.Field[i] = 0; //Очищаем клетку противника
                    enemy.Fields[i] = null;
                }
            }
        }
        Console.WriteLine("ИИ завершил свой ход. Начинается атака!");
        ////////////////////////////////////////////////////////
        //Процесс атаки
        for (int i = 0; i < 4; i++) //Цикл проходится по клеткам обоих игроков
        {
            if (player.Field[i] != 0) //Если на клетке есть карта игрока
            {
                if (enemy.Field[i] != 0) //Если на клетке напротив есть карта противника
                {
                    player.Fields[i].Hit(enemy.Fields[i]); //Удар по карте противника
                    if (enemy.Fields[i].HP <= 0) //Если удар оказался достаточно сильным
                    {
                        enemy.Field[i] = 0; //Очищаем клетку противника
                        enemy.Fields[i] = null;
                    }
                }
                else
                {
                    player.Fields[i].Hit(enemy);
                }
            }
        }
    }

    private void CellClearing (Player player, int index)
    {
        for (int i = 0; i < 6; i++)
        {
            if (player.Deck[i] == index)
            {
                player.Deck[i] = 0;
                break;
            }
        }
    }

    private void PrintSituation(Player player, Player enemy)
    {

        Console.WriteLine($"Башня противника: {enemy.HP} HP\n");    
        
        
        for(int i = 0; i < 4; i++) //Поменять объект, переменные с ХП и персонажей
        {
            if (enemy.Field[i] == 1) //Поменять переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    Console.Write($"\tСуртур:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Water)
                {
                    Console.Write($"\tПосейдон:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Earth)
                {
                    Console.Write($"\tГигант:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Air)
                {
                    Console.Write($"\tШторм:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
            }
            else if (enemy.Field[i] == 2) //Поменять условие, переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    Console.Write($"\tХранитель:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Water)
                {
                    Console.Write($"\tВодная стена:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урон");
                }
                else if (enemy is Earth)
                {
                    Console.Write($"\tДрево Жизни:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Air)
                {
                    Console.Write($"\tОрёл:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
            }
            else if (enemy.Field[i] == 3) //Поменять условие, переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    Console.Write($"\tРыцарь:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Water)
                {
                    Console.Write($"\tАквамен:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Earth)
                {
                    Console.Write($"\tКаменные братья:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Air)
                {
                    Console.Write($"\tНиндзя:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
            }
            else if (enemy.Field[i] == 4) //Поменять условие, переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    Console.Write($"\tДух Огня:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Water)
                {
                    Console.Write($"\tДух Воды:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Earth)
                {
                    Console.Write($"\tДух Земли:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
                else if (enemy is Air)
                {
                    Console.Write($"\tДух Воздуха:{enemy.Fields[i].HP} HP,{enemy.Fields[i].Damage} урона");
                }
            }
            else
            {
                Console.Write("\tПусто");
            }
        }

        Console.WriteLine("\n\n");

        for (int i = 0; i < 4; i++) //Поменять объект, переменные с ХП и персонажей
        {
            if (player.Field[i] == 1) //Поменять переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    Console.Write($"\tСуртур:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Water)
                {
                    Console.Write($"\tПосейдон:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Earth)
                {
                    Console.Write($"\tГигант:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Air)
                {
                    Console.Write($"\tШторм:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
            }
            else if (player.Field[i] == 2) //Поменять условие, переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    Console.Write($"\tХранитель:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Water)
                {
                    Console.Write($"\tВодная стена:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Earth)
                {
                    Console.Write($"\tДрево Жизни:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Air)
                {
                    Console.Write($"\tОрёл:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
            }
            else if (player.Field[i] == 3) //Поменять условие, переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    Console.Write($"\tРыцарь:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Water)
                {
                    Console.Write($"\tАквамен:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Earth)
                {
                    Console.Write($"\tКаменные братья:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Air)
                {
                    Console.Write($"\tНиндзя:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
            }
            else if (player.Field[i] == 4) //Поменять условие, переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    Console.Write($"\tДух Огня:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Water)
                {
                    Console.Write($"\tДух Воды:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Earth)
                {
                    Console.Write($"\tДух Земли:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
                else if (player is Air)
                {
                    Console.Write($"\tДух Воздуха:{player.Fields[i].HP} HP,{player.Fields[i].Damage} урона");
                }
            }
            else
            {
                Console.Write("\tПусто");
            }
        }

        Console.WriteLine("\n");
        Console.WriteLine($"Ваша башня: {player.HP} HP\n");
        Console.WriteLine("Ваша колода:\n");

        for (int i = 0; i < 6; i++)
        {
            if (player.Deck[i] == 1)
            {
                if (player is Fire) 
                {
                    Console.Write("\t1.Суртур"); 
                }
                else if (player is Water)
                {
                    Console.Write("\t1.Посейдон");
                }
                else if (player is Earth)
                {
                    Console.Write("\t1.Гигант");
                }
                else if (player is Air)
                {
                    Console.Write("\t1.Шторм");
                }
            }
            else if (player.Deck[i] == 2)
            {
                if (player is Fire)
                {
                    Console.Write("\t2.Хранитель");
                }
                else if (player is Water)
                {
                    Console.Write("\t2.Водная стена");
                }
                else if (player is Earth)
                {
                    Console.Write("\t2.Древо Жизни");
                }
                else if (player is Air)
                {
                    Console.Write("\t2.Орёл");
                }
            }
            else if (player.Deck[i] == 3)
            {
                if (player is Fire)
                {
                    Console.Write("\t3.Рыцарь");
                }
                else if (player is Water)
                {
                    Console.Write("\t3.Аквамен");
                }
                else if (player is Earth)
                {
                    Console.Write("\t3.Каменные братья");
                }
                else if (player is Air)
                {
                    Console.Write("\t3.Ниндзя");
                }
            }
            else if (player.Deck[i] == 4)
            {
                if (player is Fire)
                {
                    Console.Write("\t4.Дух Огня");
                }
                else if (player is Water)
                {
                    Console.Write("\t4.Дух Воды");
                }
                else if (player is Earth)
                {
                    Console.Write("\t4.Дух Земли");
                }
                else if (player is Air)
                {
                    Console.Write("\t4.Дух Воздуха");
                }
            }
            else
            {
                Console.Write("\tПусто");
            }
        }
        Console.WriteLine("\n");
    }
}