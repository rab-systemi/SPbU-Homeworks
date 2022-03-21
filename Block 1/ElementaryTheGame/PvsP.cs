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

        if (firstTurn == 1) //Первым ходит Игрок 1
        {
            Console.WriteLine("Первым ходит Игрок 1! Он получает 2 карты, Игрок 2 получает 3 карты\n");
            playerNew.GetCards(1); //Игрок 1 получил 2 карты, дека не пуста
            enemyNew.GetCards(2); //Игрок 2 получил 3 карты, дека не пуста
            Console.WriteLine("\n\t\tИгрок 1 делает свой ход!\n");

            playerNew.Move(playerNew, enemyNew); //Первый ход Игрока 1
            turns++;
        }
        else //Первым ходит Игрок 2
        {
            Console.WriteLine("Первым ходит Игрок 2!  Он получает 2 карты, Игрок 1 получает 3 карты\n");
            enemyNew.GetCards(1); //Игрок 2 получил 2 карты, дека не пуста
            playerNew.GetCards(2); //Игрок 1 получил 3 карты, дека не пуста
            Console.WriteLine("\n\t\tИгрок 2 делает свой ход!\n");

            enemyNew.Move(enemyNew, playerNew); //Первый ход Игрока 2
            
        }
        
        while (playerNew.HP > 0 && enemyNew.HP > 0) //Пока у обоих Игроков ХП больше 0
        {
            if(turns % 2 != 0) //Если ход нечетный
            {
                Console.WriteLine("\n\t\tИгрок 1 делает свой ход!\n");
                playerNew.Move(playerNew, enemyNew); //Ходит Игрок 1
            }
            else //Если ход четный
            {
                Console.WriteLine("\n\t\tИгрок 2 делает свой ход!\n");
                enemyNew.Move(enemyNew, playerNew); //Ходит Игрок 2
            }
            turns++;
        }
        if (playerNew.HP <= 0) //Если ХП Игрока 1 меньше 0 или равно 0
        {
            Console.WriteLine("\nИгрок 2 победил! Игра окончена!");
        }
        else //Если ХП Игрока 2 меньше 0 или равно 0
        {
            Console.WriteLine("\nИгрок 1 победил! Игра окончена!");
        }
    }
}
