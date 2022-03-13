public class Player
{
    public int HP = 100;
    public int Damage;
    public int[] Field = new int[4]; //Поле игрока для карт, содержит 4 места
    public void GetDamage(int damage) //Метод получения урона
    {
        HP -= damage;
    }
    public void ChooseYourElement()
    {

        while (true) //Ждем от пользователя нажатия клавиши. Если он нажал что-то не то, ждем снова
        {
            Console.TreatControlCAsInput = true; //На всякий случай ограничиваем пользователя от нажатия CTRL+C
            ConsoleKeyInfo Choice = Console.ReadKey();

            if (Choice.Key == ConsoleKey.D1) //Пользователь нажал 1
            {
                Console.WriteLine("\nВы выбрали стихию Огня");
                break;
            }
            else if (Choice.Key == ConsoleKey.D2) //Пользователь нажал 2
            {
                Console.WriteLine("\nВы выбрали стихию Воды");
                break;
            }
            else if (Choice.Key == ConsoleKey.D3) //Пользователь нажал 3
            {
                Console.WriteLine("\nВы выбрали стихию Земли");
                break;
            }
            else if (Choice.Key == ConsoleKey.D4) //Пользователь нажал 4
            {
                Console.WriteLine("\nВы выбрали стихию Воздуха");
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
    public int RandomValue() //Метод, случайно выбирающий число от 1 до 4
    {
        Random random = new Random();
        int value = random.Next(1, 5);

        return value;
    }
}