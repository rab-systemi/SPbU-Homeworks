public class Fire : Player
{
    public Fire(int HP, int Damage)
    {
        this.HP = HP;
        this.Damage = Damage;
    }
    public void FireAbility(Player enemy) //Абилка персонажа стихии огня
    {
        enemy.GetDamage(10);
    }
}

public class Knight : Fire
{
    public Knight(int HP = 7, int Damage = 10) : base(HP, Damage) { }
}

public class Guardian : Fire
{
    public Guardian(int HP = 14, int Damage = 3) : base(HP, Damage) { }
}

public class Surtur : Fire
{
    public Surtur(int HP = 20, int Damage = 20) : base(HP, Damage) { }
}

public class FireSpirit : Fire
{
    public FireSpirit(int HP = 3, int Damage = 3) : base(HP, Damage) { }
}