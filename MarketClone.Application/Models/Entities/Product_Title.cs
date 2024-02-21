namespace MarketClone.Application.Models.Entities;

public class Product_Title
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
    
}