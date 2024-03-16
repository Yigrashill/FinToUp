namespace Domain.Models.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime? Createrd { get; set; }
    public DateTime? Updated { get; set; }
}
