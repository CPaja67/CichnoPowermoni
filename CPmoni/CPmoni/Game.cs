using System.ComponentModel.Design;

class Game{

    public List<CPmon> VsichniCPmoni = new List<CPmon>();
    public List<CPmon> VsichniDostupniCPmoni = new List<CPmon>();
    public List<Item> VsechnyItemy = new List<Item>();
    public List<Schopnost> VsechnySchopnosti = new List<Schopnost>();
    public List<string> VsechnyJmenaCPmonu { get; set; }
    public List<string> VsechnyJmenaSchopnosti { get; set; }
    public List<string> VsechnyJmenaEfektu { get; set; }
    public Hrac player;


    //print funkce pro lehci printeni
    void PrintBarva(string input, ConsoleColor barva)
    {
        Console.ForegroundColor = barva;
        Console.Write(input);
        Console.ForegroundColor = ConsoleColor.White;
    }


    void PrintCPmonStats(CPmon cpmon)
    {
        Console.Write("\n");
        PrintBarva(cpmon.Jmeno, cpmon.Color);
        Console.Write("\nHP: ");
        PrintBarva(cpmon.Health.ToString() + " / " + cpmon.MaxHealth.ToString(), ConsoleColor.DarkGreen);
        Console.Write("\nDefense: ");
        PrintBarva(cpmon.Defense.ToString(), ConsoleColor.Gray);
        Console.Write("\nLevel: ");
        PrintBarva(cpmon.Level.ToString(), ConsoleColor.Yellow);
        Console.Write("\nSchopnosti: ");
        foreach(Schopnost s in cpmon.Schopnosti)
        {
            Console.Write("\n");
            PrintBarva(s.Jmeno, ConsoleColor.Cyan);
            Console.Write("\n - Level Requirement: ");
            PrintBarva(s.LevelReq.ToString(), ConsoleColor.DarkYellow);
            Console.Write("\n - Damage: ");
            PrintBarva(s.Damage.ToString(), ConsoleColor.Red);
            Console.Write("\n - Crit Chance: ");
            PrintBarva(s.CritChance.ToString(), ConsoleColor.DarkRed);
            Console.Write("\n - Cooldown: ");
            PrintBarva(s.Cooldown.ToString(), ConsoleColor.DarkCyan);

            /* NEFAKA EFEKTY NEJSOU IMPLEMENTOVANY, ALE KDYBY BYLY, TAK BY SE PRINTOVALY TAKTO:
            Console.Write("\n - Effects: ");
            foreach(Effect e in s.StatusEffects)
            {
                Console.Write("\n --- " + e.Jmeno);
            }
            */
        }
    }











    //starter funce



    void CreateCPmons()
    {
        Random random = new Random();
        for (int i = 0; i < 40; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaCPmonu.Count());
            int health = random.Next(10, 20);
            int defense = random.Next(0, 5);

            CPmon CPmon = new CPmon(VsechnyJmenaCPmonu[nameIndex], health, defense);
            VsechnyJmenaCPmonu.RemoveAt(nameIndex);
            VsichniCPmoni.Add(CPmon);
        }

        VsichniDostupniCPmoni = VsichniCPmoni;
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
            // pak udelej
    }

     

    public Game()
    {
        VsechnyJmenaCPmonu = new List<string>() {"Begginov","Regginald", "Vrbac", "Flusak", "Fildax", "Pikok", "Cammer", "Smiller", "Hrdlova koza", "Rovno zubac", "Slopper", "Ligman", "Tulo", "Hyggus", "Featus", "Kirox", "Michilus", "Krkax", "Grower", "Treelax", "Sifilas", "Teemor", "Tumorax", "Gutalux", "Kneacker", "Aidus", "Drafilax", "Zetyrox", "Lukylax", "Sajminax", "Somcokotax", "Kinarux", "Weertax", "Syntox", "Lollytaz", "Makarax", "Akratux", "Apilox", "Herektex", "Evickus", "Chlubimir", "Ghassys", "Chlorence", "Egmin", "Deformed Disgusting Ugly Fat Swine", "Eppsyn", "David Ngo Phong", "polykac", "uzounek", "narazec", "lapylus", "deralit", "mogudaw", "negares", "casius", "perverzius", "cigitas", "begatas", "uranius", "hoshkuz", "galartos", "breberkus", "riditegas", "mocnygas", "kneegrower", "floydus", "kirkmaq", "urhafis" }; 
        VsechnyJmenaSchopnosti = new List<string>() {"Cvachtani", "Vrceni", "Ocasni Bic", "Sladky Polibek", "Bubnovani na Bricho", "Kourova Clona", "Ztvrdnuti", "Nitovy Strih", "Liznuti", "Vyplatni Den", "Metronom", "Darecek", "Lichoceni", "Namyvka", "Kastrace", "Chrapani", "Pomlekovani", "Uvareni vajec", "Flakovani", "Zivnuti", "Vycvakavani", "Vztek", "Frustrace", "Navrat", "Rychla Ruka", "Po Tobe", "Zruseni","Vzruseni", "Kolibavy Tanec", "Lechtani", "Oslava", "Dobra Hlava", "Rychla Hvezda", "Strihnuti", "Hod Kamene","Hod Hraskem", "Uskrceni", "Analni Inpsekce", "Postrikani", "Rucni Prace", "Uder Hlavou", "Tezke Nohy", "Klouzave Nozky", "Lobotomie", "Vyvrcholeni", "Spiritualni Dotek", "vsaknuti", "prehlt", "rychle nasazeni", "cracknuti", "rychly uhyb", "fajny kotoul", "hybernace", "snow balls", "obkrojeni", "kojeni", "revize", "rewatch", "svacina", "prestrojeni", "pitny rezim", "rychly jazyk", "hod daleky", "mocny dym", "mokry sen" }; 
        CreateCPmons();
        CreateSchopnosti();
        CreateItems();
        StartGame();
    }



    void StartGame()
    {
        bool loop = true;
        Random random = new Random();

        //vyber jmena

        while (loop)
        {
            string Input, ChosenJmeno;
            Console.WriteLine("jak se jmenujes?");
            ChosenJmeno = Console.ReadLine();
            if(ChosenJmeno == "")
            {
                ChosenJmeno = "Hrac";
            }

            Console.Write("chces se takto jmenovat? (y/n)");
            Input = Console.ReadLine();

            if (Input == "y")
            {
                player = new Hrac(ChosenJmeno);
                loop = false;
            }
        }

        // vyber prvniho CPmona


        CPmon jedna, dva, tri;
        jedna = VsichniDostupniCPmoni[random.Next(0, VsichniDostupniCPmoni.Count)];
        VsichniDostupniCPmoni.Remove(jedna);
        dva = VsichniDostupniCPmoni[random.Next(0, VsichniDostupniCPmoni.Count)];
        VsichniDostupniCPmoni.Remove(dva);
        tri = VsichniDostupniCPmoni[random.Next(0, VsichniDostupniCPmoni.Count)];
        VsichniDostupniCPmoni.Remove(tri);

        loop = true;
        while (loop)
        {
            string input;
            Console.Clear();

            Console.Write("Vitej ");
            PrintBarva(player.Jmeno, ConsoleColor.Blue);
            Console.Write(", vyber si sveho prvniho Cichnapowermona\n");
            Console.Write("\n\n 1) ------------------------\n");
            PrintCPmonStats(jedna);
            Console.Write("\n\n 2) ------------------------\n");
            PrintCPmonStats(dva);
            Console.Write("\n\n 3) ------------------------\n");
            PrintCPmonStats(tri);
            Console.Write("\n\n vyber (1-3): ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    player.UloveniCPmoni.Add(jedna);
                    loop = false;
                    break;
                case "2":
                    player.UloveniCPmoni.Add(dva);
                    loop = false;
                    break;
                case "3":
                    player.UloveniCPmoni.Add(tri);
                    loop = false;
                    break;
            }
        }


        Console.Clear();
        Console.WriteLine("skvele, tvuj prvni CPmon je: ");
        PrintCPmonStats(player.UloveniCPmoni[0]);
        Console.WriteLine("\n\n stiskni enter pro pokracovani...");
        Console.ReadLine();



        //start main menu

        MainMenu();
    }



    void MainMenu()
    {

        // main menu loop, tady se bude dít většina věcí, tady se bude bojovat, nakupovat, atd.       BTW tohle autocomplete AI ktery je v Visual studiu je nejaky moc dobry ono to vi co chci udelat to je divny pomoc
        bool loop = true;
        string input;
        while (loop)
        {

            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("   _______      __                ____                                                _ ");
            Console.WriteLine("  / ____(_)____/ /_  ____  ____ _/ __ \\____ _      _____  _________ ___  ____  ____  (_)");
            Console.WriteLine(" / /   / / ___/ __ \\/ __ \\/ __ `/ /_/ / __ \\ | /| / / _ \\/ ___/ __ `__ \\/ __ \\/ __ \\/ / ");
            Console.WriteLine("/ /___/ / /__/ / / / / / / /_/ / ____/ /_/ / |/ |/ /  __/ /  / / / / / / /_/ / / / / /  ");
            Console.WriteLine("\\____/_/\\___/_/ /_/_/ /_/\\__,_/_/    \\____/|__/|__/\\___/_/  /_/ /_/ /_/\\____/_/ /_/_/   ");
            Console.ForegroundColor = ConsoleColor.White;



            Console.Write("\nco chces delat?");
            PrintBarva("\n 1) ", ConsoleColor.Red);
            PrintBarva("Jit do sveta a ", ConsoleColor.DarkRed);
            PrintBarva("bojovat", ConsoleColor.Red);
            PrintBarva("\n 2) ", ConsoleColor.Yellow);
            PrintBarva("Navstivit obchod", ConsoleColor.DarkYellow);
            PrintBarva("\n 3) ", ConsoleColor.Green);
            PrintBarva("Podivat se na CPmony", ConsoleColor.DarkGreen);
            PrintBarva("\n 4) ", ConsoleColor.Magenta);
            PrintBarva("Otevrit inventar", ConsoleColor.DarkMagenta);
            PrintBarva("\n 5) ", ConsoleColor.Gray);
            PrintBarva("Skocit z mostu (konec hry)", ConsoleColor.DarkGray);
            Console.Write("\n\n(1-5): ");

            input = Console.ReadLine();
            if (input != "")
            {
                switch (input)
                {
                    case "1":
                        StartFight();
                        break;
                    case "2":
                        Shop();
                        break;
                    case "3":
                        ShowCPmoni();
                        break;
                    case "4":
                        Inventory();
                        break;
                    case "5":
                        loop = false;
                        EndGame();
                        break;
                }
            }


            //konec loopu
        }




        // konec main menu funce (tezke si pamatovat tolik zavorek)
    }


    void StartFight()
    {
        Console.Clear();
        // fight tady 
    }

    void Shop()
    {
        Console.Clear();
        // shop tady
    }

    void ShowCPmoni()
    {
        Console.Clear();
        // zobrazovani CPmonu tady
    }

    void Inventory()
    {
        Console.Clear();
        // zobrazovani inventare tady
    }

    void EndGame()
    {
        Console.Clear();
        Console.WriteLine("diky za hru!");
        PrintBarva("\nvytvorili: ", ConsoleColor.Gray);
        PrintBarva("\n\nPavel Klusak", ConsoleColor.Red);
        PrintBarva("\nDaniel Smilek", ConsoleColor.DarkRed);
        PrintBarva("\nFilip Blazek", ConsoleColor.DarkMagenta);
        PrintBarva("\n\n\nBojoval jsi statecne,", ConsoleColor.Gray);
        PrintBarva(player.Jmeno, ConsoleColor.Blue);
        PrintBarva(", ale nakonec jsi byl premozen...", ConsoleColor.Gray);
        Console.WriteLine("\n\n stiskni enter pro ukonceni...");
        Console.ReadLine();
    }





}
