using Domain.Models.Common;

namespace Domain.Models;

public class Finance : BaseEntity
{
    public string Title { get; set; }
    public FinanceType FinanceType { get; set; }
    public decimal? Amount { get; set; } = 0.00M;

    public Finance()
    {
        base.Createrd = DateTime.Now;
    }

    public Finance(DateTime date)
    {
        base.Createrd = date;
    }
}
