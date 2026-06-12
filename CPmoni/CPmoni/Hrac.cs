class Hrac
{

    public string Jmeno { get; set; }
    public int Penize = 10;
    public int Vyhry = 0;
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
