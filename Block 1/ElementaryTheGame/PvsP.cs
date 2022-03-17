public class PvsP
{
    
    public void RunPvsP(Player player, Player enemy) //Метод, запускающий битву в режиме Игрок против Игрока
    {
        Console.WriteLine("Игрок 1, пожалуйста, выберите стихию, нажав на клавишу с соответствующим номером:");
        var playerNew = player.ChooseYourElement(); //Игрок 1 выбирает стихию

        Console.WriteLine("Игрок 2, пожалуйста, выберите стихию, нажав на клавишу с соответствующим номером:");
        var enemyNew = enemy.ChooseYourElement(); //Игрок 2 выбирает стихию

        Random Turn = new Random(); //Случайно выбираем номер игрока, делающего первый ход
        int firstTurn = Turn.Next(1, 3);
        int turns = 1; //Счетчик ходов

        if (firstTurn == 1)
        {
            Console.WriteLine("Первым ходит Игрок 1! Он получает 2 карты, Игрок 2 получает 3 карты\n");
            playerNew.GetCards(1); //Игрок 1 получил 2 карты, дека не пуста
            enemyNew.GetCards(2); //Игрок 2 получил 3 карты, дека не пуста
            Console.WriteLine("\n\tИгрок 1 делает свой ход!\n");

            playerNew.Move(playerNew, enemyNew);
            turns++;
        }
        else
        {
            Console.WriteLine("Первым ходит Игрок 2!  Он получает 2 карты, Игрок 1 получает 3 карты\n");
            enemyNew.GetCards(1); //Игрок 2 получил 2 карты, дека не пуста
            playerNew.GetCards(2); //Игрок 1 получил 3 карты, дека не пуста
            Console.WriteLine("\n\tИгрок 2 делает свой ход!\n");

            enemyNew.Move(enemyNew, playerNew);
            
        }
        
        while (playerNew.HP > 0 && enemyNew.HP > 0)
        {
            if(turns % 2 != 0)
            {
                Console.WriteLine("\n\tИгрок 1 делает свой ход!\n");
                playerNew.Move(playerNew, enemyNew);
            }
            else
            {
                Console.WriteLine("\n\tИгрок 2 делает свой ход!\n");
                enemyNew.Move(enemyNew, playerNew);
            }
            turns++;
        }
        if (playerNew.HP <= 0)
        {
            Console.WriteLine("\nИгрок 2 победил! Игра окончена!");
        }
        else
        {
            Console.WriteLine("\nИгрок 1 победил! Игра окончена!");
        }
        
    }
}
