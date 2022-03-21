public class Earth : Player //Стихия Земли
{
    public Earth()
    {
        HP = 100;
        Damage = 6;
    }

    public override void Ability(Player player, Player enemy) //Абилка персонажа стихии Земли
    {
        for (int i = 0; i < 4; i++)
        {
            if (enemy.Field[i] != 0)
            {
                enemy.Fields[i].GetDamage(Damage);
            }
        }
    }
    public override void Hit(Player enemy) //Способность удара картами одной из стихий
    {                                      //Башней использоваться не может
        enemy.GetDamage(Damage);
    }
}

public class StoneBrothers : Earth //Каменные братья
{
    public StoneBrothers() : base()
    {
        HP = 12;
        Damage = 8;
    }
}

public class TreeOfLife : Earth //Древо Жизни
{
    public TreeOfLife() : base()
    {
        HP = 20;
        Damage = 0;
    }
}

public class Giant : Earth //Гигант
{
    public Giant() : base()
    {
        HP = 23;
        Damage = 17;
    }
}

public class EarthSpirit : Earth //Дух Земли
{
    public EarthSpirit() : base()
    {
        HP = 3;
        Damage = 3;
    }
}