namespace Domain.Models;

public class Finance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public FinanceType Type { get; set; }
    public decimal Amount { get; set; } = 0.00M;
    public DateTime DateTime { get; init; }

    public Finance()
    {
        DateTime = DateTime.Now;
    }

    public Finance(DateTime date)
    {
        DateTime = date;
    }

}
