class Schopnost{

    public string Jmeno {  get; set; }
    public int Damage { get; set; }
    public int CritChance { get; set; }
    public int Cooldown { get; set; }
    public int CurrentCooldown { get; set; }
    public int LevelReq { get; set; }
    public List<Effect> StatusEffects { get; set; }

    public Schopnost(string jmeno, int damage, int critchance, List<Effect> statuseffects, int cooldown = 1, int levelreq = 0 )
    {
        Jmeno = jmeno;
        Damage = damage;
        CritChance = critchance;
        Cooldown = cooldown;
        CurrentCooldown = Cooldown;
        if (statuseffects == null) return;
        for (int i = 0; i < statuseffects.Count; i++)
        {
            StatusEffects.Add(statuseffects[i]);
        }
    }

}
