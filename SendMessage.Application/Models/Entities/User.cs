using SendMessage.Application.Models.Common;

namespace SendMessage.Application.Models.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public DateOnly BirthDate { get; set; }
}