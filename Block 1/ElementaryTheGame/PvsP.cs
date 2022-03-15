public class PvsP
{
    
    Player playerField2 = new();
    Player playerField3 = new();
    Player playerField4 = new();
    Player enemyField1 = new();
    Player enemyField2 = new();
    Player enemyField3 = new();
    Player enemyField4 = new();

    public Player playerField1 = new Player(); //Test
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
            Console.WriteLine("Первым ходит Игрок 1! Он получает 2 карты, Игрок 2 получает 3 карты");
            playerNew.GetCards(2); //Игрок 1 получил 2 карты, дека не пуста
            enemyNew.GetCards(3); //Игрок 2 получил 3 карты, дека не пуста
            Console.WriteLine("Игрок 1 делает свой ход!");
            playerNew.Move(playerNew, enemyNew, playerField1, playerField2, playerField3, playerField4,
                enemyField1, enemyField2, enemyField3, enemyField4);
            turns++;
            Console.WriteLine(playerField1.HP);
        }
        else
        {
            Console.WriteLine("Первым ходит Игрок 2!  Он получает 2 карты, Игрок 1 получает 3 карты");
            enemyNew.GetCards(2); //Игрок 2 получил 2 карты, дека не пуста
            playerNew.GetCards(3); //Игрок 1 получил 3 карты, дека не пуста
            Console.WriteLine("Игрок 2 делает свой ход!");
            enemyNew.Move(enemyNew, playerNew, playerField1, playerField2, playerField3, playerField4,
                enemyField1, enemyField2, enemyField3, enemyField4);
            
        }
        /*
        while(playerNew.HP > 0 || enemyNew.HP > 0)
        {
            if(turns % 2 != 0)
            {
                Console.WriteLine("Игрок 1 делает свой ход!");
                //playerNew.Move();
            }
            else
            {
                Console.WriteLine("Игрок 2 делает свой ход!");
                //enemyNew.Move();
            }
            turns++;
        }
        */
    }
}
