public class Player
{
    public int HP = 100;
    public int Damage;
    public int[] Field = new int[4]; //Поле игрока для карт, содержит 4 места
    public int[] Deck = new int[6]; //Колода игрока, максимум - 6 карт

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
            case ConsoleKey.D2: //Если пользователь выбрал стихию Воды
                return new Water();
            case ConsoleKey.D3: //Если пользователь выбрал стихию Земли
                return new Earth();
            case ConsoleKey.D4: //Если пользователь выбрал стихию Воздуха
                return new Air();
            default:
                return null;
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
            int cardToDelete = random.Next(0, 6);
            bool flag = false;
            for (int j = 0; j < 6; j++)
            {
                if (Deck[j] == 0)
                {
                    Deck[j] = randomCard;
                    flag = true;
                    break;
                }
                else continue;
            }
            if (!flag)
            {
                Deck[cardToDelete] = randomCard;
            }
        }
    }
    public void Move(Player player, Player enemy)
    {
        Player knight = new Knight();
        Player guardian = new Guardian();
        Player surtur = new Surtur();
        Player fireSpirit = new FireSpirit();

        Player aquaman = new Aquaman();
        Player wall = new Wall();
        Player poseidon = new Poseidon();
        Player waterSpirit = new WaterSpirit();

        Player stoneBrothers = new StoneBrothers();
        Player treeOfLife = new TreeOfLife();
        Player giant = new Giant();
        Player earthSpirit = new EarthSpirit();

        Player ninja = new Ninja();
        Player eagle = new Eagle();
        Player storm = new Storm();
        Player airSpirit = new AirSpirit();

        player.GetCards(1);
        Console.WriteLine("Вы получили карту в начале хода");
        
    }
    
}