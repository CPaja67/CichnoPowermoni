class Shop{

    public List<Item> Items = new List<Item>();
    public List<int> ItemPrices = new List<int>();
    public CPmon AvailableCPmon {  get; set; }
    public int CPmonPrice { get; set; }



    public Shop(CPmon availableCPmon, List<Item> items, int vyhry)
    {
        AvailableCPmon = availableCPmon;
        if (items == null) return;

        for (int i = 0; i < items.Count; i++)
        {
            Items.Add(items[i]);
        }

        SetPrices(vyhry);
    }


    void SetPrices(int vyhry)
    {
        Random random = new Random();
        CPmonPrice = 4 * (vyhry + 1) + random.Next(1, 6);

        for (int i = 0; i < 3; i++)
        {
            ItemPrices.Add(random.Next(5, 20));
        }
    }


    public void VypisShop()
    {
        Console.Write("\nDnes si muzes koupit ");

    }
}
