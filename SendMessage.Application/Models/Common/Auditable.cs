namespace SendMessage.Application.Models.Common;

public abstract class Auditable:BaseEntity
{
    public DateTime UpdateDate { get; set; }
    
    public DateTime CreatedDate { get; set; }
}
