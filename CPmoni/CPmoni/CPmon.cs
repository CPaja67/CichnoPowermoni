using System.Reflection.Emit;

class CPmon
{
    public string Jmeno {  get; set; }
    public ConsoleColor Color { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Defense { get; set; }
    public int Level { get; set; }
    public List<Schopnost> Schopnosti = new List<Schopnost> { };
    public List<int> SchopnostiCooldown = new List<int> { }; // jak dlouho jsou schopnosti v cooldownu
    public List<Effect> AktivniEffecty = new List<Effect> { };
    public List<int> AktivniEffectyDecay = new List<int> { }; // jak dlouho jsou effecty aktivni

    public CPmon(string jmeno, int maxhealth, int defense,int level = 0)
    {
        Jmeno = jmeno;
        MaxHealth = maxhealth;
        Color = ConsoleColor.Green;
        Health = MaxHealth;
        Defense = defense;
        Level = level;

    }


}
