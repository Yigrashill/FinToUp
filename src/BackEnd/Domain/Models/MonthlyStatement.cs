using Domain.Models.Common;

namespace Domain.Models;

public class MonthlyStatement : BaseEntity
{
    public string Title { get; set; }
    public List<Finance> MonthBalance { get; set; }
    public DateOnly Month { get; set; }
}
