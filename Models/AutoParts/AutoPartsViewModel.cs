public class AutoPartsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public AutoPartsViewModel(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    // Add this indexer
    public int this[int index]
    {
        get { return Id; }
        set { Id = value; }
    }
}
