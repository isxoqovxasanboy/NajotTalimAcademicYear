namespace MarketClone.Application.Models.Entities;

public class Location
{
    public int Id { get; set; }
    
    public string Address { get; set; } = default!;

    public int LocationCityId { get; set; } 
}