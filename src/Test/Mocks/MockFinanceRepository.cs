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
            new Finance() {Id = 1, Title = "Biedronka", Amount = -50.00M},
            new Finance() {Id = 2, Title = "Wypłata", Amount = 1000.00M},
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
