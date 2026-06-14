using System.ComponentModel.Design;
using System.Runtime.InteropServices.Marshalling;

class Game{

    public List<CPmon> VsichniCPmoni = new List<CPmon>();
    public List<CPmon> VsichniDostupniCPmoni = new List<CPmon>();
    public List<Item> VsechnyItemy = new List<Item>();

    public List<Schopnost> VsechnySchopnosti = new List<Schopnost>();
    public List<Schopnost> VsechnySchopnostiLevel0 = new List<Schopnost>();
    public List<Schopnost> VsechnySchopnostiLevel5 = new List<Schopnost>();
    public List<Schopnost> VsechnySchopnostiLevel10 = new List<Schopnost>();
    public List<Schopnost> VsechnySchopnostiLevel20 = new List<Schopnost>();

    public List<string> VsechnyJmenaCPmonu { get; set; }
    public List<string> VsechnyJmenaSchopnosti { get; set; }
    public List<string> VsechnyJmenaTreneru { get; set; }
    public List<string> VsechnyJmenaItemu { get; set; }
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
        int x = 1;
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
            Console.Write("\n-------------\n" + x + ")");
            x++;
            PrintBarva(s.Jmeno, s.Barva);
            Console.Write("\n - Level Requirement: ");
            PrintBarva(s.LevelReq.ToString(), ConsoleColor.DarkYellow);
            if(cpmon.Level < s.LevelReq) PrintBarva(" --- LOCKED", ConsoleColor.DarkRed);
            Console.Write("\n * Damage: ");
            PrintBarva(s.Damage.ToString(), ConsoleColor.Red);
            Console.Write("\n * Crit Chance: ");
            PrintBarva(s.CritChance.ToString(), ConsoleColor.DarkRed);
            Console.Write("\n - Cooldown: ");
            PrintBarva(s.Cooldown.ToString() + " / " + cpmon.SchopnostiCooldown[x-2].ToString(), ConsoleColor.DarkCyan);

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
            int nameIndex = random.Next(0, VsechnyJmenaCPmonu.Count);
            int health = random.Next(10, 20);
            int defense = random.Next(0, 5);

            CPmon Cpmon = new CPmon(VsechnyJmenaCPmonu[nameIndex], health, defense);

            // kazdy CPmon ma 2 lvl0, 1 lvl5, 1 lvl10 a 1 lvl20 schopnost

            int index = random.Next(0, VsechnySchopnostiLevel0.Count);
            Cpmon.Schopnosti.Add(VsechnySchopnostiLevel0[index]);
            Cpmon.SchopnostiCooldown.Add(VsechnySchopnostiLevel0[index].Cooldown);

            index = random.Next(0, VsechnySchopnostiLevel0.Count);
            Cpmon.Schopnosti.Add(VsechnySchopnostiLevel0[index]);
            Cpmon.SchopnostiCooldown.Add(VsechnySchopnostiLevel0[index].Cooldown);

            index = random.Next(0, VsechnySchopnostiLevel5.Count);
            Cpmon.Schopnosti.Add(VsechnySchopnostiLevel5[index]);
            Cpmon.SchopnostiCooldown.Add(VsechnySchopnostiLevel5[index].Cooldown);

            index = random.Next(0, VsechnySchopnostiLevel10.Count);
            Cpmon.Schopnosti.Add(VsechnySchopnostiLevel10[index]);
            Cpmon.SchopnostiCooldown.Add(VsechnySchopnostiLevel10[index].Cooldown);

            index = random.Next(0, VsechnySchopnostiLevel20.Count);
            Cpmon.Schopnosti.Add(VsechnySchopnostiLevel20[index]);
            Cpmon.SchopnostiCooldown.Add(VsechnySchopnostiLevel20[index].Cooldown);

            VsechnyJmenaCPmonu.RemoveAt(nameIndex);
            VsichniCPmoni.Add(Cpmon);
        }

        VsichniDostupniCPmoni = VsichniCPmoni;
    }



    void CreateSchopnosti()
    {
        Random random = new Random();
        
        //level 0
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(2,4);
            int crit = random.Next(5, 20);
            int cooldown = random.Next(1, 2);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> {},ConsoleColor.Cyan,cooldown, 0);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
            VsechnySchopnostiLevel0.Add(Schopnost);

        }
        //level 5
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(10, 20);
            int crit = random.Next(10, 30);
            int cooldown = random.Next(2, 3);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> { },ConsoleColor.DarkCyan, cooldown, 5);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
            VsechnySchopnostiLevel5.Add(Schopnost);
        }
        //level 10
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(20, 40);
            int crit = random.Next(20, 50);
            int cooldown = random.Next(3, 5);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> { },ConsoleColor.DarkMagenta, cooldown, 10);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
            VsechnySchopnostiLevel10.Add(Schopnost);
        }
        //level 20
        for (int i = 0; i < 10; i++)
        {
            int nameIndex = random.Next(0, VsechnyJmenaSchopnosti.Count());
            int damage = random.Next(50, 110);
            int crit = random.Next(10, 70);
            int cooldown = random.Next(4, 8);

            Schopnost Schopnost = new Schopnost(VsechnyJmenaSchopnosti[nameIndex], damage, crit, new List<Effect> { },ConsoleColor.Magenta, cooldown, 20);
            VsechnyJmenaSchopnosti.RemoveAt(nameIndex);
            VsechnySchopnosti.Add(Schopnost);
            VsechnySchopnostiLevel20.Add(Schopnost);
        }
    }




    void CreateItems()
    {
        Item item = new Item(VsechnyJmenaItemu[0], "SmallHeal");
        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            int index = random.Next(0, VsechnyJmenaItemu.Count);
            int jmenoIndex = random.Next(0, 11);
            switch (jmenoIndex)
            {
                case 0:
                    item = new Item(VsechnyJmenaItemu[index], "SmallHeal");
                    break;
                case 1:
                    item = new Item(VsechnyJmenaItemu[index], "MediumHeal");
                    break;
                case 2:
                    item = new Item(VsechnyJmenaItemu[index], "BigHeal");
                    break;
                case 3:
                    item = new Item(VsechnyJmenaItemu[index], "SmallDamage");
                    break;
                case 4:
                    item = new Item(VsechnyJmenaItemu[index], "MediumDamage");
                    break;
                case 5:
                    item = new Item(VsechnyJmenaItemu[index], "BigDamage");
                    break;
                case 6:
                    item = new Item(VsechnyJmenaItemu[index], "Cleanse");
                    break;
                case 7:
                    item = new Item(VsechnyJmenaItemu[index], "Fire");
                    break;
                case 8:
                    item = new Item(VsechnyJmenaItemu[index], "Poison");
                    break;
                case 9:
                    item = new Item(VsechnyJmenaItemu[index], "Sleep");
                    break;
                case 10:
                    item = new Item(VsechnyJmenaItemu[index], "Stun");
                    break;

            }
            VsechnyJmenaItemu.RemoveAt(index);
            VsechnyItemy.Add(item);
        }
    }

     

    public Game()
    {
        VsechnyJmenaCPmonu = new List<string>() {"Begginov","Regginald", "Vrbac", "Flusak", "Fildax", "Pikok", "Cammer", "Smiller", "Hrdlova koza", "Rovno zubac", "Slopper", "Ligman", "Tulo", "Hyggus", "Featus", "Kirox", "Michilus", "Krkax", "Grower", "Treelax", "Sifilas", "Teemor", "Tumorax", "Gutalux", "Kneacker", "Aidus", "Drafilax", "Zetyrox", "Lukylax", "Sajminax", "Somcokotax", "Kinarux", "Weertax", "Syntox", "Lollytaz", "Makarax", "Akratux", "Apilox", "Herektex", "Evickus", "Chlubimir", "Ghassys", "Chlorence", "Egmin", "Deformed Disgusting Ugly Fat Swine", "Eppsyn", "David Ngo Phong", "polykac", "uzounek", "narazec", "lapylus", "deralit", "mogudaw", "negares", "casius", "perverzius", "cigitas", "begatas", "uranius", "hoshkuz", "galartos", "breberkus", "riditegas", "mocnygas", "kneegrower", "floydus", "kirkmaq", "urhafis" }; 
        VsechnyJmenaSchopnosti = new List<string>() {"Cvachtani", "Vrceni", "Ocasni Bic", "Sladky Polibek", "Prasknuti Gumy", "Bubnovani na Bricho", "Kourova Clona", "HIV infekce", "Ztvrdnuti", "Nitovy Strih", "Liznuti", "Vyplatni Den", "Metronom", "Darecek", "Lichoceni", "Namyvka", "Kastrace", "Chrapani", "Pomlekovani", "Uvareni vajec", "Flakovani", "Zivnuti", "Vycvakavani", "Vztek", "Frustrace", "Navrat", "Rychla Ruka", "Po Tobe", "Zruseni","Vzruseni", "Kolibavy Tanec", "Lechtani", "Oslava", "Dobra Hlava", "Rychla Hvezda", "Strihnuti", "Hod Kamene","Hod Hraskem", "Uskrceni", "Analni Inpsekce", "Postrikani", "Rucni Prace", "Uder Hlavou", "Tezke Nohy", "Klouzave Nozky", "Lobotomie", "Vyvrcholeni", "Spiritualni Dotek", "vsaknuti", "prehlt", "rychle nasazeni", "cracknuti", "rychly uhyb", "fajny kotoul", "hybernace", "snow balls", "obkrojeni", "kojeni", "revize", "rewatch", "svacina", "prestrojeni", "pitny rezim", "rychly jazyk", "hod daleky", "mocny dym", "mokry sen" }; 
        VsechnyJmenaTreneru = new List<string>() { "Zdenek", "Ferko Lacko", "Franta Majitel", "Uzka Vrba", "Jeff Einstein", "Bibi", "Bigus Eveckus", "Kotny Somko", "Uvolneny Leicman", "Daniel", "Sweetie Fox", "Vladimir Putin", "Vrrrbka", "Nichulicka", "Kleinmann", "Grossfrau"};
        VsechnyJmenaItemu = new List<string>() { "Lahvicka Mleka", "Kofola", "Pivko", "Flaska Vina", "Plesnivy Syr", "Suchy Rohlik", "Stary Boty", "Pouzity Kondom", "Prsten Sily", "Posmrkany Kapesnik", "CD", "Prosly Jogurt", "Smradlave Ponozky", "Kanalizacni Krysa", "AIDS", "Plastovy Sacek S Krvi", "Faktura", "Scat", "Piskoty", "Hypoteka na Dum", "Reprak"};
        CreateSchopnosti();
        CreateCPmons();
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
            string ChosenJmeno;
            Console.WriteLine("jak se jmenujes?");
            ChosenJmeno = Console.ReadLine();
            if(ChosenJmeno == "")
            {
                ChosenJmeno = "Hrac";
            }
            player = new Hrac(ChosenJmeno);
            loop = false;

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
        Console.Write("\x1b[3J\x1b[2J\x1b[H"); // tenhle divnej comand clearne uplne vsehcno, protoze ten normalni clearne jenom to co je videt, ale kdyz se scrollne nahoru, tak tam je porad ten starej text, ale tenhle ho uplne smaze, je to divny ale funguje to
        Console.WriteLine("skvele, tvuj prvni CPmon je: ");
        PrintCPmonStats(player.UloveniCPmoni[0]);
        player.UlovenychCPmonu++;
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
        //generace shopu aby byl fresh pokazde
        Shop shop = GenerateShop();

        while (loop)
        {
            if (player.UloveniCPmoni.Count == 0)
            {
                EndGame();
                loop = false; break;
            }
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("   _______      __                ____                                                _ ");
            Console.WriteLine("  / ____(_)____/ /_  ____  ____ _/ __ \\____ _      _____  _________ ___  ____  ____  (_)");
            Console.WriteLine(" / /   / / ___/ __ \\/ __ \\/ __ `/ /_/ / __ \\ | /| / / _ \\/ ___/ __ `__ \\/ __ \\/ __ \\/ / ");
            Console.WriteLine("/ /___/ / /__/ / / / / / / /_/ / ____/ /_/ / |/ |/ /  __/ /  / / / / / / /_/ / / / / /  ");
            Console.WriteLine("\\____/_/\\___/_/ /_/_/ /_/\\__,_/_/    \\____/|__/|__/\\___/_/  /_/ /_/ /_/\\____/_/ /_/_/   ");
            Console.ForegroundColor = ConsoleColor.White;



            Console.Write("\nco chces delat?");
            PrintBarva("\n 1) ", ConsoleColor.DarkRed);
            PrintBarva("Jit do sveta a ", ConsoleColor.Red);
            PrintBarva("bojovat", ConsoleColor.DarkRed);
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
                        shop = GenerateShop();
                        break;
                    case "2":
                        Shop(shop);
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
        string input;
        int index = 0;
        bool loop = true;


        // vybrani a balance protivnika
        Random random = new Random();
        int indexCPmona = random.Next(0, VsichniDostupniCPmoni.Count);
        Protihrac protivnik = new Protihrac(VsechnyJmenaTreneru[random.Next(0, VsechnyJmenaTreneru.Count)], VsichniDostupniCPmoni[indexCPmona]);
        VsichniDostupniCPmoni[indexCPmona].Level = player.Vyhry + random.Next(0, 2);
        VsichniDostupniCPmoni.RemoveAt(indexCPmona);

        // trochu napeti pred fightem
        Console.Clear();
        Console.Write("Putoval jsi po svete... (enter)");
        Console.ReadLine();
        Console.Write("...a nasel jsi...");
        Console.ReadLine();
        Console.Write("Divokeho ");
        PrintBarva(protivnik.Jmeno, protivnik.Barva);
        Console.ReadLine();

        //vyber s cim budes fightit
        Console.WriteLine("\nVyber si sveho CPmona: ");
        VypisCPmonu();
        while (true)
        {
            Console.Write("vyber: ");
            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out index))
            {
                if (index >= 1 && index <= player.UloveniCPmoni.Count)
                {
                    break; // platný výběr
                }
            }

            Console.WriteLine("Neplatný výběr");
        }
        player.VybranyCPmon = player.UloveniCPmoni[index - 1];
        Fight(protivnik);
    }


    
    void Fight(Protihrac protivnik)
    {
        string input;
        bool loop = true;

        Console.Clear();
        Console.Write("souboj mezi ");
        PrintBarva(player.VybranyCPmon.Jmeno, player.VybranyCPmon.Color);
        Console.Write(" a ");
        PrintBarva(protivnik.EnemyCPmon.Jmeno, protivnik.Barva);
        Console.Write(" zacina! (enter)");
        Console.ReadLine();

        // loop fightu (turns)
        while (loop)
        {
            Console.Clear();
            Console.Write("\x1b[3J\x1b[2J\x1b[H"); // tady zase clear vseho protoze ty staty jsou moc dlouhy

            // turn hraca
            Console.Write("Jsi na rade, ");
            PrintBarva(player.Jmeno, ConsoleColor.Blue);
            Console.WriteLine(", co budes delat?");

            PrintBarva("\n 1) Zautocit", ConsoleColor.Red);
            PrintBarva("\n 2) Itemy", ConsoleColor.DarkMagenta);
            PrintBarva("\n 3) Obrana", ConsoleColor.Gray);
            PrintBarva("\n 4) Inspectnout CPmony (nebere tvuj tah)", ConsoleColor.Green);
            Console.Write("\n\n(1-4): ");

            input = Console.ReadLine();
            if (input != "")
            {
                switch (input)
                {
                    case "1":

                        Console.Clear();
                        //utok
                        Utok(protivnik);
                        //check jestli zije enemy
                        if (protivnik.EnemyCPmon.Health <= 0) 
                        {
                            loop = KonecTahu(protivnik.EnemyCPmon);
                            break;
                        }
                        Console.WriteLine(""); 

                        //enemy ukot

                        EnemyTah(protivnik);
                        //konec tahu
                        loop = KonecTahu(protivnik.EnemyCPmon);
                        break;
                    case "2":
                      
                        break;
                    case "3":

                        Console.Clear();
                        //defense
                        player.VybranyCPmon.Brani = true;
                        PrintBarva(player.VybranyCPmon.Jmeno , player.VybranyCPmon.Color);
                        Console.Write(" se brani ");
                        PrintBarva("(dostane jen 1/2 damage)\n", ConsoleColor.DarkGray);
                        Console.ReadLine();

                        EnemyTah(protivnik);
                        loop = KonecTahu(protivnik.EnemyCPmon);

                        break;
                    case "4":
                        Console.Clear();
                        PrintBarva("\nTvuj CPmon:", ConsoleColor.Blue);
                        PrintCPmonStats(player.VybranyCPmon);
                        PrintBarva("\n\n\n\n\nProtivnikuv CPmon:", ConsoleColor.Red);
                        PrintCPmonStats(protivnik.EnemyCPmon);
                        Console.ReadLine();
                        break;
                }
            }



        }


    }




    // TAHY ---------------



    //player utok
    void Utok(Protihrac protivnik)
    {
        bool loop = true;
        while (loop)
        {
            string input;
            int index = 0;
            Console.Clear();
            PrintCPmonStats(player.VybranyCPmon);
            Console.WriteLine("\nvyber schopnost: ");
            input = Console.ReadLine();
            if (input != "")
            {
                index = int.Parse(input);
                if(index > 0 && index <= player.VybranyCPmon.Schopnosti.Count)
                {
                    Schopnost zvolenaSchopnost = player.VybranyCPmon.Schopnosti[index - 1];
                    if (player.VybranyCPmon.Level >= zvolenaSchopnost.LevelReq)
                    {
                        if(player.VybranyCPmon.SchopnostiCooldown[index - 1] == zvolenaSchopnost.Cooldown)
                        {
                            player.VybranyCPmon.SchopnostiCooldown[index - 1] = 0;

                            // tady se dela utoceni
                            Console.Clear();
                            PrintBarva(player.VybranyCPmon.Jmeno, player.VybranyCPmon.Color);
                            Console.Write(" pouzil ");
                            PrintBarva(zvolenaSchopnost.Jmeno, zvolenaSchopnost.Barva);
                            player.PocetPouzitychSchopnosti++;
                            Console.ReadLine();
                            AplikujDamage(zvolenaSchopnost, protivnik.EnemyCPmon);
                            Console.ReadLine();
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Tato schopnost je v cooldownu, musis pockat " + player.VybranyCPmon.SchopnostiCooldown[index - 1] + " tahu");
                            Console.WriteLine("\n\nstiskni enter pro pokracovani...");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tato schopnost je zamcena, musis dosahnout levelu " + zvolenaSchopnost.LevelReq + " pro pouziti");
                        Console.WriteLine("\n\nstiskni enter pro pokracovani...");
                        Console.ReadLine();
                    }
                }
            }
        }
    }


    // enemy utok

    void EnemyTah(Protihrac protivnik)
    {
        Random random = new Random();
        if (random.Next(0, 100) < 10)
        {
            // 10% sance ze enemy nebude utocit
            PrintBarva(protivnik.EnemyCPmon.Jmeno, ConsoleColor.DarkRed);
            Console.Write(" zakopnul!");
            PrintBarva(" (nehraje tah)", ConsoleColor.DarkGray);
            Console.ReadLine();
        }
        else if(random.Next(0, 100) < 30)
        {
            // 20% sance ze enemy bude defendovat
            PrintBarva(protivnik.EnemyCPmon.Jmeno, ConsoleColor.DarkRed);
            Console.Write(" se brani!");
            PrintBarva(" (pristi kolo dostane jenom 1/2 damage)", ConsoleColor.DarkGray);
            protivnik.EnemyCPmon.Brani = true;
            Console.ReadLine();
        }
        else
        {
            EnemyUtok(protivnik);
        }
    }



    void EnemyUtok(Protihrac protivnik)
    {
        bool loop = true;
        Random random = new Random();
        int index = random.Next(0, protivnik.EnemyCPmon.Schopnosti.Count);
        Schopnost zvolenaSchopnost = protivnik.EnemyCPmon.Schopnosti[index];

        while (loop)
        {
            if (zvolenaSchopnost.LevelReq <= protivnik.EnemyCPmon.Level && protivnik.EnemyCPmon.SchopnostiCooldown[index] == zvolenaSchopnost.Cooldown)
            {
                zvolenaSchopnost = protivnik.EnemyCPmon.Schopnosti[index];
                loop = false;
                break;
            }
            index = random.Next(0, protivnik.EnemyCPmon.Schopnosti.Count);
            zvolenaSchopnost = protivnik.EnemyCPmon.Schopnosti[index];
        }
        PrintBarva(protivnik.EnemyCPmon.Jmeno, ConsoleColor.DarkRed);
        Console.Write(" pouzil ");
        PrintBarva(zvolenaSchopnost.Jmeno, zvolenaSchopnost.Barva);
        Console.ReadLine();
        AplikujEnemyDamage(zvolenaSchopnost, player.VybranyCPmon, protivnik);
        Console.ReadLine();
    }




    // damage do tvyho CPmonu
    void AplikujEnemyDamage(Schopnost schopnost, CPmon kdo, Protihrac protivnik)
    {
        int damage = schopnost.Damage - kdo.Defense;
        if (kdo.Brani)
        {
            damage = damage / 2;
            PrintBarva(kdo.Jmeno, kdo.Color);
            PrintBarva(" zabranil utok, ", ConsoleColor.DarkGray);
            kdo.Brani = false;
        }

        if (damage <= 0) damage = 1;
        PrintBarva(protivnik.EnemyCPmon.Jmeno, ConsoleColor.DarkRed);
        Console.Write(" zpusobil ");
        PrintBarva(damage.ToString() + " damage", ConsoleColor.Red);
        kdo.Health -= damage;

        if (schopnost.CritChance > new Random().Next(0, 100))
        {
            PrintBarva("\n" +protivnik.EnemyCPmon.Jmeno, ConsoleColor.DarkRed);
            PrintBarva(" zasahl kriticky, zpusobil jeste " + damage + " damage!", ConsoleColor.DarkRed);
            kdo.Health -= damage;
        }

        Console.ReadLine();
        PrintBarva("Zbyvajici HP tvyho CPmona: " + kdo.Health.ToString() + " / " + kdo.MaxHealth.ToString(), ConsoleColor.DarkGreen);
    }




    // damage do enemy CPmonu
    void AplikujDamage(Schopnost schopnost, CPmon kdo)
    {
        int damage = schopnost.Damage - kdo.Defense;
        if (kdo.Brani)
        {
            damage = damage / 2;
            PrintBarva(kdo.Jmeno, ConsoleColor.DarkRed);
            PrintBarva(" zabranil utok, ", ConsoleColor.DarkGray); 
            kdo.Brani = false;
        }

        if (damage <= 0) damage = 1;
        PrintBarva(player.VybranyCPmon.Jmeno, player.VybranyCPmon.Color);
        Console.Write(" zpusobil ");
        PrintBarva(damage.ToString() + " damage", ConsoleColor.Red);
        kdo.Health -= damage;
        player.CelkovyDamageDealt += damage;

        if (schopnost.CritChance > new Random().Next(0, 100))
        {
            PrintBarva("\nCriticky zasah, Zpusobil jsi jeste " + damage + " damage!", ConsoleColor.DarkRed);
            kdo.Health -= damage;
            player.CelkovyDamageDealt += damage;
        }

        Console.ReadLine();
        PrintBarva("Protivnikuv zbyvajici HP: " + kdo.Health.ToString() + " / " + kdo.MaxHealth.ToString(), ConsoleColor.DarkGreen);
        /*
        if(schopnost.StatusEffects.Count > 0)
        {
            foreach (Effect e in schopnost.StatusEffects)
            {
                Console.WriteLine("Zpusobil jsi efekt ktery nejsou jeste"); // ZMENIUT
                // AplikujEffect(e, kdo, false);
            }
        }
        */
    }




    void AplikujEffect(Effect vybranyEffect, Protihrac protihrac, bool Kdo)
    {
        // True = hrac, false = protivnik
        Random random = new Random();
        switch (vybranyEffect.Jmeno)
        {

            // Nemuze nic delat na pocet tahu
            case "Stun":

                break;
            // Nemuze nic delat dokud nedas DMG
            case "Spanek":
                break;

            // Dealne malo dmg ze zacatku a potom zesily
            case "Otraveni":
                int MaxHpScale = protihrac.EnemyCPmon.MaxHealth / 25;
                int damage = random.Next(1, 2);
                break;

            // Dealne hodne dmg a potom zeslabne
            case "Paleni":
                break;
            // Zacne % regen podle Hp
            case "Regenerace":
                break;
            // Dostane tolik hp kolik da dmg
            case "Kradez Zivota":
                break;

            // snizi defense
            case "Ziravina":
                break;

        }


    }



    bool KonecTahu(CPmon enemyCPmon)
    {
        // umrel enemyCPmon
        if (enemyCPmon.Health <= 0)
        {
            int mone = 0;
            Console.Write("Gratuluji, porazil jsi protivnika! (enter)");
            Console.ReadLine();
            player.Vyhry++;
            mone = new Random().Next(4, 10) * player.Vyhry;
            player.Penize += mone;
            player.CelkovyPenize += mone;
            Console.Write("Ziskal jsi ");
            PrintBarva(mone.ToString() + " penizku", ConsoleColor.DarkYellow);
            Console.ReadLine();
            player.VybranyCPmon.Level += 1;
            Console.Write("Tvuj CPmon se level-upnul na level ");
            PrintBarva(player.VybranyCPmon.Level.ToString(), ConsoleColor.Yellow);
            Console.ReadLine();
            Console.Write("nini je "); 
            PrintBarva(enemyCPmon.Jmeno, enemyCPmon.Color);
            Console.Write(" v tvem arsenalu!");
            //heal CPmonu
            enemyCPmon.Health = enemyCPmon.MaxHealth;
            //healne tvyho 20% HP
            if (player.VybranyCPmon.MaxHealth / 5 + player.VybranyCPmon.Health > player.VybranyCPmon.MaxHealth)
            {
                player.VybranyCPmon.Health = player.VybranyCPmon.MaxHealth;
            }
            else
            {
                player.VybranyCPmon.Health = player.VybranyCPmon.MaxHealth / 5;
            }
            player.UloveniCPmoni.Add(enemyCPmon);
            player.UlovenychCPmonu++;
            Console.ReadLine();
            return false;
        }

        // umrel tvuj CPmon
        if (player.VybranyCPmon.Health <= 0)
        {
            player.VybranyCPmon.Health = player.VybranyCPmon.MaxHealth;
            VsichniDostupniCPmoni.Add(player.VybranyCPmon);
            player.UloveniCPmoni.Remove(player.VybranyCPmon);
            player.VybranyCPmon = null;
            return false;
        }

        //cooldown tick pro hrace

        foreach (Schopnost s in player.VybranyCPmon.Schopnosti)
        {
            int index = player.VybranyCPmon.Schopnosti.IndexOf(s);
            if (player.VybranyCPmon.SchopnostiCooldown[index] < s.Cooldown)
            {
                player.VybranyCPmon.SchopnostiCooldown[index]++;
            }
        }

        //cooldown tick pro enemy CPmona
        foreach (Schopnost s in enemyCPmon.Schopnosti)
        {
            int index = enemyCPmon.Schopnosti.IndexOf(s);
            if (enemyCPmon.SchopnostiCooldown[index] < s.Cooldown)
            {
                enemyCPmon.SchopnostiCooldown[index]++;
            }
        }
        return true;
    }



    // vypis vsech ulovenych CPmonu a jejich staty
    void VypisCPmonu()
    {
        int x = 0;
        foreach (CPmon cpmon in player.UloveniCPmoni)
        {
            x++;
            Console.WriteLine(x + ")");
            PrintCPmonStats(cpmon);
            Console.WriteLine("\n-----------------------------------\n");
        }
    }




    Shop GenerateShop()
    {
        Random random = new Random();
        List<Item> items = new List<Item>();
        int index;
        for (int i = 0; i < 3; i++)
        {
            items.Add(VsechnyItemy[random.Next(0, VsechnyItemy.Count)]);
        }
        index = random.Next(0, VsichniDostupniCPmoni.Count);
        Shop shop = new Shop(VsichniDostupniCPmoni[index], items, player.Vyhry);
        VsichniDostupniCPmoni.RemoveAt(index);
        return shop;
    }


    void Shop(Shop shop)
    {
        Random random = new Random();
        string input;
        int parsedInput, index;
        bool loop = true;


        //loop shopu pro neschopne lidi co neumi psat spravne
        while (loop)
        {
            VypisShopu(shop);
            Console.Write("\n\nCo to teda bude? (1-4, 5 = odchod): ");
            input = Console.ReadLine();

            if (input != "" && int.TryParse(input, out parsedInput))
            {
                parsedInput = int.Parse(input);
                if (parsedInput > 0 && parsedInput < 6)
                {
                    switch (parsedInput)
                    {
                        //CPmon
                        case 1:
                            Console.Clear();
                            PrintCPmonStats(shop.AvailableCPmon);
                            Console.Write("\n\nChces si tuhle krasku koupit za ");
                            PrintBarva(shop.CPmonPrice + " penizku?", ConsoleColor.DarkYellow);
                            PrintBarva(" (y/n)", ConsoleColor.DarkGray);
                            input = Console.ReadLine();
                            if (input == "y") 
                            {
                                //kdyz na to ma a che
                                if (CheckPenez(shop.CPmonPrice))
                                {
                                    player.Penize -= shop.CPmonPrice;
                                    player.UloveniCPmoni.Add(shop.AvailableCPmon);
                                    shop.VykoupeniCPmona();
                                    player.UlovenychCPmonu++;
                                }
                                //nema money
                                else
                                {
                                    Console.WriteLine("Je mi lito, ale nemas na to prachy");
                                    Console.ReadLine();
                                }
                            }
                            // nenchce
                            else
                            {
                                Console.WriteLine("\nBud si neco vyber nebo vypal!");
                                Console.ReadLine();
                            }
                            break;


                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:
                            Console.Write("\nNashledanou, ");
                            PrintBarva(player.Jmeno, ConsoleColor.Cyan);
                            loop = false;
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }


    void VypisShopu(Shop shop)
    {
        Console.Clear();
        Console.Write("Ahoj, ");
        PrintBarva(player.Jmeno, ConsoleColor.Cyan);
        if (shop.AvailableCPmon != null) 
        {
            Console.Write(", dneska je na vyber ");
            PrintBarva(shop.AvailableCPmon.Jmeno, shop.AvailableCPmon.Color);
            Console.Write("\nnebo jestli sis prisel pro nejake predmety, muzu ti nabidnout ");
        }
        else
        {
            Console.Write(", uz sis dnesniho CPmona koupil...");
            Console.Write("\nnebo jestli sis prisel pro nejake predmety, muzu ti nabidnout ");
        }

        foreach(Item i in shop.Items)
        {
            PrintBarva(i.Jmeno + ", ", ConsoleColor.DarkMagenta);
        }
        Console.Write("\nMas ");
        PrintBarva(player.Penize + " penizku", ConsoleColor.DarkYellow);
    }


    bool CheckPenez(int price)
    {
        if(player.Penize >= price)
        {
            return true;
        }
        return false;
    }



    void BuyItemu(Item item) 
    {

    }





    void ShowCPmoni()
    {
        Console.Clear();
        PrintBarva("Tvoji CPmoni:\n\n", ConsoleColor.Blue);
        foreach (CPmon cpmon in player.UloveniCPmoni)
        {
            PrintCPmonStats(cpmon);
            Console.WriteLine("\n-----------------------------------\n");
        }
        Console.WriteLine("\n\n(enter)");
        Console.ReadLine();
    }

    void Inventory()
    {
        Console.Clear();
        // zobrazovani inventare tady
    }


    void VypsaniStatu() 
    {
        Console.WriteLine("Staty:");
        PrintBarva("\nVyhry: " + player.Vyhry.ToString(), ConsoleColor.Yellow);
        PrintBarva("\nCelkem ziskano penez: " + player.CelkovyPenize.ToString(), ConsoleColor.DarkYellow);
        PrintBarva("\nPocet Pouzitych schopnosti: " + player.PocetPouzitychSchopnosti.ToString(), ConsoleColor.DarkMagenta);
        PrintBarva("\nUloveni CPmoni: " + player.UlovenychCPmonu.ToString(), ConsoleColor.Green);
    }

    void EndGame()
    {
        Console.Clear();
        Console.WriteLine("diky za hru!");
        PrintBarva("\nvytvorili: ", ConsoleColor.Gray);
        PrintBarva("\n\nPavel Klusak", ConsoleColor.Red);
        PrintBarva("\nDaniel Smilek", ConsoleColor.DarkRed);
        PrintBarva("\nFilip Blazek", ConsoleColor.DarkMagenta);
        PrintBarva("\n\n\nBojoval jsi statecne, ", ConsoleColor.Gray);
        PrintBarva(player.Jmeno, ConsoleColor.Blue);
        PrintBarva(", ale nakonec jsi byl premozen...", ConsoleColor.Gray);
        Console.WriteLine("\n\nstiskni enter pro vypsani statu...");
        Console.ReadLine();
        VypsaniStatu();
        Console.WriteLine("\n\nstiskni enter pro ukonceni...");
        Console.ReadLine();

    }





}
