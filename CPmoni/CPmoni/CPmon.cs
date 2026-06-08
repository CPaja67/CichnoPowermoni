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
    public List<Effect> AktivniEffecty { get; set; }

    public CPmon(string jmeno, int maxhealth, int defense,int level = 0)
    {
        Schopnost punch = new Schopnost("punch",3, 10, null);
        Schopnosti.Add(punch);
        Jmeno = jmeno;
        MaxHealth = maxhealth;
        Color = ConsoleColor.Green;
        Health = MaxHealth;
        Defense = defense;
        Level = level;

    }


}
