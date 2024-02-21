namespace MarketClone.Application.Models.Entities;

public class PersonContacts
{
    public int Id { get; set; }
    
    public int PersonId { get; set; }
    
    public int ContactTypeId { get; set; }

    public string ContactValue { get; set; } = default!;
}