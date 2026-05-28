using System.Reflection.Emit;

class CPmon
{
    public string Jmeno {  get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Defense { get; set; }
    public int Level { get; set; }
    public List<Schopnost> Schopnosti { get; set; }
    public List<Effect> AktivniEffecty { get; set; }

    public CPmon(string jmeno, int maxhealth, int defense,int level = 0)
    {

    }


}
