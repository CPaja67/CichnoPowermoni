class Hrac
{

    public string Jmeno { get; set; }
    public int Penize = 100;
    //staty
    public int CelkovyPenize = 10;
    public int Vyhry = 0;
    public int PocetPouzitychSchopnosti = 0;
    public int UlovenychCPmonu = 0;
    public int CelkovyDamageDealt = 0;
    public int CelkovyDamageTaken = 0;

    public List<CPmon> UloveniCPmoni = new List<CPmon>();
    public CPmon VybranyCPmon;
    public List<Item> Itemy = new List<Item>();



    public Hrac(string jmeno)
    {
        Jmeno = jmeno;
    }

    // Damage
    public void TakeDamage()
    {

    }


    public void DealDamage()
    {


    }

    // Heal
    public void Heal()
    {

    }

    // Efekty
    public void TakeEffect()
    {

    }

    public void DealEffect()
    {


    }


    // Itemy
    public void KoupitItem()
    { }

    public void SmazatItem()
    { }


    // CPMON

    public void PridatCpmon()
    { }

    public void OdebratCpmon()
    { }

}
