namespace MarketClone.Application.Models.Entities;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
    
    public DateTime BirthDate { get; set; }
}
