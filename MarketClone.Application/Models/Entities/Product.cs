namespace MarketClone.Application.Models.Entities;

public class Product
{
    public int Id { get; set; }
    
    public int TitleId { get; set; }
    
    public int ManufacturerId { get; set; }
    
    public int SupplierId { get; set; }
    
    public decimal UnitPrice { get; set; }

    public string Comment { get; set; } = default!;
}