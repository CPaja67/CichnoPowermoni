class Item{
  public string Jmeno {get; set;}
  public string Typ {get; set;}
  public 
}

public void PouzitItem()
{
    Random random = new Random();

    


    switch (Typ)
    {
        case "SmallHeal":
            int heal = random.Next(4,8);


            break;
        case "MediumHeal":

            break;
        case "BigHeal":

            break;
        case "SmallDamage":

            break;
        case "MediumDamage":

            break;
        case "BigDamage":

            break;
        case "Cleanse":

            break;
        case "Fire":

            break;
        case "Poison":

            break;
        case "Sleep":

            break;
        case "Stun":

            break;
    }
        

}





public Item(string jmeno, string typ) 
{
    Jmeno = jmeno;
    Typ = typ;
}
