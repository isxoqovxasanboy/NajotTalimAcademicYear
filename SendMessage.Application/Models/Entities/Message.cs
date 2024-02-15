using SendMessage.Application.Models.Common;

namespace SendMessage.Application.Models.Entities;

public class Message
{
    public Guid SenderId { get; set; }
    public string Body { get; set; } = default!;
    public string Title { get; set; } = default!;
}