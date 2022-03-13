public class Air : Player
{
    public Air(int HP, int Damage)
    {
        this.HP = HP;
        this.Damage = Damage;
    }
}

public class Ninja : Air
{
    public Ninja(int HP = 8, int Damage = 12) : base(HP, Damage) { }
}

public class Eagle : Air
{
    public Eagle(int HP = 15, int Damage = 5) : base(HP, Damage) { }
}

public class Storm : Air
{
    public Storm(int HP = 19, int Damage = 21) : base(HP, Damage) { }
}

public class AirSpirit : Air
{
    public AirSpirit(int HP = 3, int Damage = 3) : base(HP, Damage) { }
}