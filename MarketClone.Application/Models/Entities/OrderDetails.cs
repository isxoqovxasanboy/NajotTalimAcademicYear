namespace MarketClone.Application.Models.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    
    public int ProductId { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal PriceWithDiscount { get; set; }
    
    public int ProductAmount { get; set; }
    
}