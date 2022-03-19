public class Water : Player
{
    public Water()
    {
        HP = 100;
        Damage = 3;
    }

    public override void Ability(Player player, Player enemy) //Абилка персонажа стихии Воды
    {
        enemy.GetDamage(Damage);
        for(int i = 0; i < 4; i++)
        {
            if(enemy.Field[i] != 0)
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

public class Aquaman : Water
{
    public Aquaman() : base()
    {
        HP = 10;
        Damage = 10;
    }
}

public class Wall : Water
{
    public Wall() : base()
    {
        HP = 17;
        Damage = 1;
    }
}

public class Poseidon : Water
{
    public Poseidon() : base()
    {
        HP = 17;
        Damage = 23;
    }
}

public class WaterSpirit : Water
{
    public WaterSpirit() : base()
    {
        HP = 3;
        Damage = 3;
    }
}