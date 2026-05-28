class Game{

    public List<CPmon> VsichniCPmoni {  get; set; }
    public List<Item> VsechnyItemy { get; set; }
    public List<Schopnost> VsechnySchopnosti { get; set; }
    public List<string> VsechnyJmenaCPmonu { get; set; }
    public List<string> VsechnyJmenaSchopnosti { get; set; }


    void CreateCPmon()
    {
        Random randomName = new Random();
        for (int i = 0; i < 30; i++)
        {
            int nameIndex = randomName.Next(0, VsechnyJmenaCPmonu.Count());
            int health = randomName.Next(10, 20);
            int defense = randomName.Next(0, 5);

            CPmon CPmon = new CPmon(VsechnyJmenaCPmonu[nameIndex], health, defense);
            VsichniCPmoni.Add(CPmon);
            
        }
    }


    public Game()
    {
        CreateCPmon();

    }

}
