public class Earth : Player
{
    public Earth(int HP, int Damage)
    {
        this.HP = HP;
        this.Damage = Damage;
    }
}

public class StoneBrothers : Earth
{
    public StoneBrothers(int HP = 12, int Damage = 8) : base(HP, Damage) { }
}

public class TreeOfLife : Earth
{
    public TreeOfLife(int HP = 20, int Damage = 0) : base(HP, Damage) { }
}

public class Giant : Earth
{
    public Giant(int HP = 23, int Damage = 15) : base(HP, Damage) { }
}

public class EarthSpirit : Earth
{
    public EarthSpirit(int HP = 3, int Damage = 3) : base(HP, Damage) { }
}