class Protihrac{

    public string Jmeno { get; set; }
    public ConsoleColor Barva { get; set; }
    public CPmon EnemyCPmon { get; set; }

    public Protihrac(string jmeno, CPmon enemycpmon, ConsoleColor barva = ConsoleColor.DarkRed)
    {
        Jmeno = jmeno;
        Barva = barva;
        EnemyCPmon = enemycpmon;
    }


}
