public class Earth : Player
{
    public Earth()
    {
        HP = 100;
        Damage = 6;
    }

    public override void Ability(Player enemy) //Абилка персонажа стихии Земли
    {

    }
    public override void Hit(Player enemy) //Способность удара картами одной из стихий
    {                                      //Башней использоваться не может
        enemy.GetDamage(Damage);
    }
}

public class StoneBrothers : Earth
{
    public StoneBrothers() : base()
    {
        HP = 12;
        Damage = 8;
    }
}

public class TreeOfLife : Earth
{
    public TreeOfLife() : base()
    {
        HP = 20;
        Damage = 0;
    }
}

public class Giant : Earth
{
    public Giant() : base()
    {
        HP = 23;
        Damage = 15;
    }
}

public class EarthSpirit : Earth
{
    public EarthSpirit() : base()
    {
        HP = 3;
        Damage = 3;
    }
}