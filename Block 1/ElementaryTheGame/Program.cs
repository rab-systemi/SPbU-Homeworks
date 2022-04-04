using System;

namespace ElementaryTheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(); //Создаем игрока 1
            Player player2 = new Player(); //Создаем игрока 2

            Fight game = new Fight(); //Создаем игру

            game.Start(player1, player2); //Начинается игра

            Console.WriteLine("\n\n\nНажмите любую клавишу, чтобы выйти из игры");
            Console.ReadKey();
        }
    }
}