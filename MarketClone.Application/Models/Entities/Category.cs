namespace MarketClone.Application.Models.Entities;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    private IList<Product_Title> Titles { get; set; }
}