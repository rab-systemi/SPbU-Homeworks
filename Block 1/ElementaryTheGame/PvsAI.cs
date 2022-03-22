public class PvsAI
{
    public void RunPvsAI(Player player, Player enemy) //Метод, запускающий битву в режиме Игрок против ИИ
    {
        Console.WriteLine("Игрок 1, пожалуйста, выберите стихию, нажав на клавишу с соответствующим номером:");
        var playerNew = player.ChooseYourElement(); //Игрок 1 выбирает стихию

        Console.WriteLine("Игрок 2 выбирает стихию!\n");
        var enemyNew = enemy.ChooseElementAI(); //ИИ выбирает стихию

        Random Turn = new Random(); //Случайно выбираем номер игрока, делающего первый ход
        int firstTurn = Turn.Next(1, 3);
        int turns = 1; //Счетчик ходов

        if (firstTurn == 1) //Первым ходит Игрок
        {
            Console.WriteLine("Первым ходит Игрок 1! Он получает 2 карты, Игрок 2 получает 3 карты\n");
            playerNew.GetCards(1); //Игрок получил 2 карты, дека не пуста
            enemyNew.GetCards(2); //ИИ получил 3 карты, дека не пуста
            Console.WriteLine("\n\t\tИгрок 1 делает свой ход!\n");

            playerNew.Move(playerNew, enemyNew); //Первый ход Игрока
            turns++;
        }
        else //Первым ходит ИИ
        {
            Console.WriteLine("Первым ходит Игрок 2!  Он получает 2 карты, Игрок 1 получает 3 карты\n");
            enemyNew.GetCards(1); //ИИ получил 2 карты, дека не пуста
            playerNew.GetCards(2); //Игрок получил 3 карты, дека не пуста
            Console.WriteLine("\n\t\tИгрок 2 делает свой ход!\n");

            enemyNew.MoveAI(enemyNew, playerNew); //Первый ход ИИ

        }

        while (playerNew.HP > 0 && enemyNew.HP > 0) //Пока ХП Игрока и ИИ больше 0
        {
            if (turns % 2 != 0) //Если ход нечетный
            {
                Console.WriteLine("\n\t\tИгрок 1 делает свой ход!\n");
                playerNew.Move(playerNew, enemyNew); //Ходит Игрок
            }
            else //Если ход четный
            {
                Console.WriteLine("\n\t\tИгрок 2 делает свой ход!\n");
                enemyNew.MoveAI(enemyNew, playerNew); //Ходит ИИ
            }
            turns++;
        }
        if (playerNew.HP <= 0) //Если ХП Игрока меньше 0 или равно 0
        {
            Console.WriteLine("\nИгрок 2 победил! Игра окончена!");
        }
        else //Если ХП ИИ меньше 0 или равно 0
        {
            Console.WriteLine("\nИгрок 1 победил! Игра окончена!");
        }
    }
}