namespace SendMessage.Application.Models.Entities;

public class UserMessage
{
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
}