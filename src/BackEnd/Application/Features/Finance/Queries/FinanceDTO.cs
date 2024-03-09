namespace Application.Features.Finance.Queries;

public class FinanceDTO
{
    public int Id { get; set; }
    public DateTime? Createrd { get; }
    public DateTime? Updated { get; }
    public string Title { get; set; }
    public FinanceTypeDTO FinanceType { get; set; }
    public decimal Amount { get; set; } = 0.00M;
}

//TODO if we need FinanceTypeDTO on backend, or only int value to send by API
public enum FinanceTypeDTO
{
    Default = 0,
    Assets = 1,
    Liabilities = 2,
}