public class Player
{
    public int HP = 100;
    public int Damage;
    public int[] Field = new int[4]; //Поле игрока для карт, содержит 4 места
    public int[] Deck = new int[6]; //Рука игрока, максимум - 6 карт
    public Player[] Fields = new Player[4]; //Тоже поле игрока для карт, но в нем содержатся объекты типа Player

    public int[] FieldHPs = new int[4];

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
    public void Move(Player player, Player enemy) //Метод хода игрока
    {

        player.GetCards(1);
        Console.WriteLine("Вы получили карту в начале хода!\n\n");

        PrintSituation(player, enemy);

        

        //Console.WriteLine("Выберите карту в руке (нажмите 1,2,3 или 4), чтобы разместить на поле, " +
        //    "используйте способность стихии (нажмите A) или нажмите ENTER, чтобы завершить ход и начать атаку");

        /*
        int abilityCount = 0;
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
                        continue;
                    }
                }
                if (!flagCard)
                {
                    Console.WriteLine("У Вас в руке нет данной карты");
                    continue;
                }
            }
            else if (cardChoice.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                bool flagCard = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 2)
                    {
                        //Выбрать поле для размещения карты
                        flagCard = true;
                        continue;
                    }
                }
                if (!flagCard)
                {
                    Console.WriteLine("У Вас в руке нет данной карты");
                    continue;
                }
            }
            else if (cardChoice.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                bool flagCard = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 3)
                    {
                        //Выбрать поле для размещения карты
                        flagCard = true;
                        continue;
                    }
                }
                if (!flagCard)
                {
                    Console.WriteLine("У Вас в руке нет данной карты");
                    continue;
                }
            }
            else if (cardChoice.Key == ConsoleKey.D4) //Пользователь нажал 4
            {
                bool flagCard = false;
                for (int i = 0; i < 6; i++)
                {
                    if (player.Deck[i] == 4)
                    {
                        //Выбрать поле для размещения карты
                        flagCard = true;
                        continue;
                    }
                }
                if (!flagCard)
                {
                    Console.WriteLine("У Вас в руке нет данной карты");
                    continue;
                }
            }
            else if (cardChoice.Key == ConsoleKey.A) //Пользователь нажал A
            {
                if (abilityCount == 0)
                {
                    Console.WriteLine("\nВы применили способность башни!");
                    player.Ability(enemy); //TO CHECK
                    continue;
                }
                else
                {
                    Console.WriteLine("\nВы уже применили спсобность башни на этом ходу. Введите другое значение.");
                    continue;
                }
            }
            else if (cardChoice.Key == ConsoleKey.Enter) //Пользователь нажал ENTER
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
        */
    }
    //TO FINISH
    private void PrintSituation(Player player, Player enemy)
    {

        Console.WriteLine($"Башня противника: {enemy.HP} HP\n");    
        
        
        for(int i = 0; i < 4; i++) //Поменять объект, переменные с ХП и персонажей
        {
            if (enemy.Field[i] == 1) //Поменять переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tСуртур: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tСуртур: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Water)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tПосейдон: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tПосейдон: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Earth)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tГигант: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tГигант: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Air)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tШторм: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tШторм: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
            }
            else if (enemy.Field[i] == 2) //Поменять условие, переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tХранитель: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tХранитель: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Water)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tВодная стена: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tВодная стена: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Earth)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДрево Жизни: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДрево Жизни: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Air)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tОрёл: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tОрёл: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
            }
            else if (enemy.Field[i] == 3) //Поменять условие, переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tРыцарь: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tРыцарь: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Water)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tАквамен: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tАквамен: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Earth)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tКаменные братья: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tКаменные братья: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Air)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tНиндзя: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tНиндзя: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
            }
            else if (enemy.Field[i] == 4) //Поменять условие, переменные с ХП и персонажей
            {
                if (enemy is Fire)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Огня: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Огня: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Water)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Воды: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Воды: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Earth)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Земли: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Земли: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
                }
                else if (enemy is Air)
                {
                    if (enemy.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Воздуха: {enemy.Fields[i].HP} HP, {enemy.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Воздуха: {enemy.FieldHPs[i]} HP, {enemy.Fields[i].Damage} урона");
                    }
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
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tСуртур: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tСуртур: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Water)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tПосейдон: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tПосейдон: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Earth)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tГигант: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tГигант: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Air)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tШторм: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tШторм: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
            }
            else if (player.Field[i] == 2) //Поменять условие, переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tХранитель: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tХранитель: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Water)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tВодная стена: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tВодная стена: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Earth)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДрево Жизни: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДрево Жизни: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Air)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tОрёл: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tОрёл: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
            }
            else if (player.Field[i] == 3) //Поменять условие, переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tРыцарь: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tРыцарь: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Water)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tАквамен: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tАквамен: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Earth)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tКаменные братья: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tКаменные братья: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Air)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tНиндзя: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tНиндзя: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
            }
            else if (player.Field[i] == 4) //Поменять условие, переменные с ХП и персонажей
            {
                if (player is Fire)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Огня: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Огня: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Water)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Воды: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Воды: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Earth)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Земли: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Земли: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
                }
                else if (player is Air)
                {
                    if (player.FieldHPs[i] == 0)
                    {
                        Console.Write($"\tДух Воздуха: {player.Fields[i].HP} HP, {player.Fields[i].Damage} урона");
                    }
                    else
                    {
                        Console.Write($"\tДух Воздуха: {player.FieldHPs[i]} HP, {player.Fields[i].Damage} урона");
                    }
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