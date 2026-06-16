using System.Reflection.Emit;

class CPmon
{
    public string Jmeno {  get; set; }
    public ConsoleColor Color { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Defense { get; set; }
    public int MaxDefense { get; set; }
    public bool Brani = false;
    public int Level = 0;
    public List<Schopnost> Schopnosti = new List<Schopnost> { };
    public List<int> SchopnostiCooldown = new List<int> { }; // jak dlouho jsou schopnosti v cooldownu
    public List<Effect> AktivniEffecty = new List<Effect> { };
    public List<int> AktivniEffectyDecay = new List<int> { }; // jak dlouho jsou effecty aktivni

    public CPmon(string jmeno, int maxhealth, int defense)
    {
        Jmeno = jmeno;
        MaxHealth = maxhealth;
        Color = ConsoleColor.Green;
        Health = MaxHealth;
        Defense = defense;
        MaxDefense = defense;

    }

    public void LevelUp(int levels)
    {
        Level += levels;
        for (int i = 0; i < levels; i++)
        {
            MaxHealth = MaxHealth + MaxHealth / 4;
            Health = MaxHealth;
            MaxDefense++;
            Defense = MaxDefense;
        }
        if (Level >= 20) Color = ConsoleColor.Magenta;
    }


}
