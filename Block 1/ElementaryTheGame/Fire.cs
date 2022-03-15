public class Fire : Player
{
    public Fire()
    {
        HP = 100;
        Damage = 10;
        //ProbabilitySpace = { surtur, }
    }

    public override void Ability(Player enemy) //Абилка персонажа стихии Огня
    {
        enemy.GetDamage(Damage);
    }
    public override void Hit(Player enemy) //Способность удара картами одной из стихий
    {                                      //Башней использоваться не может
        enemy.GetDamage(Damage);
    }
}


public class Knight : Fire
{
    public Knight() : base()
    {
        HP = 7;
        Damage = 10;
    }
}


public class Guardian : Fire
{
    public Guardian() : base()
    {
        HP = 14;
        Damage = 3;
    }
}


public class Surtur : Fire
{
    public Surtur() : base()
    {
        HP = 20;
        Damage = 20;
    }
}


public class FireSpirit : Fire
{
    public FireSpirit() : base()
    {
        HP = 3;
        Damage = 3;
    }
}