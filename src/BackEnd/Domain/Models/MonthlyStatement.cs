namespace Domain.Models;

public class MonthlyStatement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Finance> MonthBalance { get; set; }
    public DateOnly Month { get; set; }
}
