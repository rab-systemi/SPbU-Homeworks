public class PvsP
{
    public void RunPvsP(Player player, Player enemy) //Метод, запускающий битву в режиме Игрок против Игрока
    {
        Console.WriteLine("Игрок 1, пожалуйста, выберите стихию, нажав на клавишу с соответствующим номером:\n");
        player.ChooseYourElement();
    }
}
