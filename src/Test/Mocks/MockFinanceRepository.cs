using Application.Contracts.Persistance;
using Domain.Models;

namespace Test.Mocks;

public class MockFinanceRepository
{
    public static Mock<IFinanceRepository> GetMockFinanceRepository()
    {
        var finances = new List<Finance>
        {
            new Finance() {Id = 1, Title = "Biedronka", Amount = 50.00M , FinanceType= FinanceType.Liabilities},
            new Finance() {Id = 2, Title = "Wypłata", Amount = 1000.00M, FinanceType = FinanceType.Assets},
            new Finance() {Id = 3, Title = "Sklep ABC", Amount = 150.00M, FinanceType = FinanceType.Liabilities},
            new Finance() {Id = 4, Title = "Czynsz", Amount = 600.00M, FinanceType = FinanceType.Liabilities},
            new Finance() {Id = 5, Title = "Abonament telefoniczny", Amount = 50.00M, FinanceType = FinanceType.Liabilities},
            new Finance() {Id = 6, Title = "Zwrot podatku", Amount = 500.00M, FinanceType = FinanceType.Assets},
            new Finance() {Id = 7, Title = "Rachunek za prąd", Amount = 100.00M, FinanceType = FinanceType.Liabilities},
            new Finance() {Id = 8, Title = "Oszczędności", Amount = 3000.00M, FinanceType = FinanceType.Assets},
            new Finance() {Id = 9, Title = "Koszty samochodu", Amount = 200.00M, FinanceType = FinanceType.Liabilities},
            new Finance() {Id = 10, Title = "Inwestycje", Amount = 1500.00M, FinanceType = FinanceType.Assets},
        };

        var mockRepo = new Mock<IFinanceRepository>();

        // Mock GetFinanceById
        #pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        mockRepo.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) =>
            {
                return finances.FirstOrDefault(f => f.Id == id);
            });
        #pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        // Mock GetAllFinance
        mockRepo.Setup(m => m.GetAsync()).ReturnsAsync(finances);

        //Mock Create New Finance
        mockRepo.Setup(m => m.CreateAsync(It.IsAny<Finance>()))
            .Returns((Finance finance) =>
            {
                finances.Add(finance);
                return Task.CompletedTask;
            });

        // Mock Update Finance
        mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Finance>()))
            .Returns((Finance finance) =>
            {
                var item = finances.FirstOrDefault(x => x.Id == finance.Id) ?? new Finance();
                item.Title = finance.Title;
                item.Amount = finance.Amount;
                item.FinanceType = finance.FinanceType;
                item.Updated = DateTime.Now;
                return Task.CompletedTask;
            });


        return mockRepo;
    }
}
