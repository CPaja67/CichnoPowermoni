class Game{

    public List<CPmon> VsichniCPmoni {  get; set; }
    public List<Item> VsechnyItemy { get; set; }
    public List<string> VsechnyJmena { get; set; }


    void JmenaAssing()
    {
        for (int i = 0; i < 30; i++)
        {
            CPmon CPmon = new CPmon();
            VsichniCPmoni.Add(CPmon);
        }
    }


    public Game()
    {
        JmenaAssing();

    }

}
