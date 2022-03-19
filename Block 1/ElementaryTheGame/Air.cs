public class Air : Player
{
    public Air()
    {
        HP = 100;
        Damage = 4;
    }

    public override void Ability(Player player, Player enemy) //Абилка персонажа стихии Воздуха
    {
        player.HP += 6;
        enemy.GetDamage(Damage);
    }
    public override void Hit(Player enemy) //Способность удара картами одной из стихий
    {                                      //Башней использоваться не может
        enemy.GetDamage(Damage);
    }
}

public class Ninja : Air
{
    public Ninja() : base()
    {
        HP = 8;
        Damage = 12;
    }
}

public class Eagle : Air
{
    public Eagle() : base()
    {
        HP = 15;
        Damage = 5;
    }
}

public class Storm : Air
{
    public Storm() : base()
    {
        HP = 19;
        Damage = 21;
    }
}

public class AirSpirit : Air
{
    public AirSpirit() : base()
    {
        HP = 3;
        Damage = 3;
    }
}