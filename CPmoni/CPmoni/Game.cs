class Game{

    public List<CPmon> VsichniCPmoni {  get; set; }
    public List<Item> VsechnyItemy { get; set; }
    public List<Schopnost> VsechnySchopnosti { get; set; }
    public List<string> VsechnyJmenaCPmonu { get; set; }
    public List<string> VsechnyJmenaSchopnosti { get; set; }


    void CreateCPmons()
    {
        Random random = new Random();
        for (int i = 0; i < 30; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaCPmonu.Count());
            int health = random.Next(10, 20);
            int defense = random.Next(0, 5);

            CPmon CPmon = new CPmon(VsechnyJmenaCPmonu[nameIndex], health, defense);
            VsechnyJmenaCPmonu.RemoveAt(nameIndex);
            VsichniCPmoni.Add(CPmon);
        }
    }


    void CreateSchopnosti()
    {
        Random random= new Random();
        
        //level 0
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(2,4);
            int crit = random.Next(5, 20);
            int cooldown = random.Next(1, 2);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> {},cooldown, 0);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);

        }
        //level 5
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(10, 20);
            int crit = random.Next(10, 30);
            int cooldown = random.Next(2, 3);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> { }, cooldown, 5);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
        }
        //level 10
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(20, 40);
            int crit = random.Next(20, 40);
            int cooldown = random.Next(3, 5);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> { }, cooldown, 10);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
        }
        //level 20
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(50, 110);
            int crit = random.Next(30, 80);
            int cooldown = random.Next(4, 8);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> { }, cooldown, 20);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
        }
    }


    void CreateItems()
    {
            
    }

     
    public Game()
    {
        VsechnyJmenaCPmonu = new List<string>() {"Begginov","Regginald", "Vrbac", "Flusak", "Fildax", "Pikok", "Cammer", "Smiller", "Hrdlova koza", "Rovno zubac", "Slopper", "Ligman", "Tulo", "Hyggus", "Featus", "Kirox", "Michilus", "Krkax", "Grower", "Treelax", "Sifilas", "Teemor", "Tumorax", "Gutalux", "Kneacker", "Aidus", "Drafilax", "Zetyrox", "Lukylax", "Sajminax", "Somcokotax", "Kinarux", "Weertax", "Syntox", "Lollytaz", "Makarax", "Akratux", "Apilox", "Herektex", "Evickus", "Chlubimir", "Ghassys", "Chlorence", "Egmin", "Deformed Disgusting Ugly Fat Swine", "Eppsyn", "David Ngo Phong"}; 
        VsechnyJmenaSchopnosti = new List<string>() {"Cvachtani", "Vrceni", "Ocasni Bic", "Sladky Polibek", "Bubnovani na Bricho", "Kourova Clona", "Ztvrdnuti", "Nitovy Strih", "Liznuti", "Vyplatni Den", "Metronom", "Darecek", "Lichoceni", "Namyvka", "Kastrace", "Chrapani", "Pomlekovani", "Uvareni vajec", "Flakovani", "Zivnuti", "Vycvakavani", "Vztek", "Frustrace", "Navrat", "Rychla Ruka", "Po Tobe", "Zruseni","Vzruseni", "Kolibavy Tanec", "Lechtani", "Oslava", "Dobra Hlava", "Rychla Hvezda", "Strihnuti", "Hod Kamene","Hod Hraskem", "Uskrceni", "Analni Inpsekce"}; 
        CreateCPmons();
        CreateSchopnosti();
        CreateItems();
    }

}
