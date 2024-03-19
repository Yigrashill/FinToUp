using Application.Contracts.Persistance;
using Domain.Models;
using Moq;

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

        // Mock GetAllFinance
        mockRepo.Setup(m => m.GetAsync()).ReturnsAsync(finances);

        //Mock Create New Finance
        mockRepo.Setup(m => m.CreateAsync(It.IsAny<Finance>()))
            .Returns((Finance finance) =>
            {
                finances.Add(finance);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
