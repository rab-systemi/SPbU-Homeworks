public class Water : Player
{
    public Water(int HP, int Damage)
    {
        this.HP = HP;
        this.Damage = Damage;
    }
}

public class Aquaman : Water
{
    public Aquaman(int HP = 10, int Damage = 10) : base(HP, Damage) { }
}

public class Wall : Water
{
    public Wall(int HP = 17, int Damage = 1) : base(HP, Damage) { }
}

public class Poseidon : Water
{
    public Poseidon(int HP = 14, int Damage = 23) : base(HP, Damage) { }
}

public class WaterSpirit : Water
{
    public WaterSpirit(int HP = 3, int Damage = 3) : base(HP, Damage) { }
}