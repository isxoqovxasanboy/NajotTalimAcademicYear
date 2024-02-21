namespace MarketClone.Application.Models.Entities;

public class Order
{
    public int Id { get; set; }
    
    public DateTime OperationTime { get; set; }
    
    public int SupermarketLocationId { get; set; }
    
    public int CustomerId { get; set; }
}