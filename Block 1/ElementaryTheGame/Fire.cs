public class Fire : Player //Стихия Огня
{
    public Fire()
    {
        HP = 100;
        Damage = 10;
    }

    public override void Ability(Player player, Player enemy) //Абилка персонажа стихии Огня
    {
        enemy.GetDamage(Damage);
    }
    public override void Hit(Player enemy) //Способность удара картами одной из стихий
    {                                      //Башней использоваться не может
        enemy.GetDamage(Damage);
    }
}


public class Knight : Fire //Рыцарь
{
    public Knight() : base()
    {
        HP = 7;
        Damage = 10;
    }
}


public class Guardian : Fire //Хранитель
{
    public Guardian() : base()
    {
        HP = 14;
        Damage = 3;
    }
}


public class Surtur : Fire //Суртур
{
    public Surtur() : base()
    {
        HP = 20;
        Damage = 20;
    }
}


public class FireSpirit : Fire //Дух Огня
{
    public FireSpirit() : base()
    {
        HP = 3;
        Damage = 3;
    }
}